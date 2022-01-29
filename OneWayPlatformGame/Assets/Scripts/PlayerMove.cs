using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    
    public float moveForce = 10f;
    public float jumpForce = 11f;
    string scenename = "";
    private Vector3 tempPos;
    private Transform player;
    public float movementX;
    public Rigidbody2D myBody;
    public Animator anim;
    public string WALK_ANIMATION = "Walk";
    public string JUMP_ANIMATION = "Jump";
    public string GROUND_TAG = "Ground";
    public string START_TAG = "Start";
    
    public string FLOOD_TAG = "Flood";
    // public string UPPLATFORM_TAG = "UpPlatform";
    private string ARROW_TAG = "ArrowTrap";
    public SpriteRenderer sr;
    public bool isGrounded; 

    public GameObject resultText;
    public GameObject resultScore;
    public GameObject LevelCompleteBG;
    public GameObject Retry;
    public GameObject Continue;

    [SerializeField]
    private float minY;

    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        scenename = scene.name;
        if(scenename != "LevelSelection"){
            LevelCompleteBG.SetActive(false);
            Close.SetActive(false);
        }
        
    }

    private bool done = false;
    float currentTime=0f;
    float startingTime=0f;
    int time = 0;
    // Update is called once per frame
    void Update()
    {
        
        if(!done){
                    currentTime +=1 * Time.deltaTime;
                    time = (int)currentTime;
                }
        Player1Movement();
        AnimatePlayer();
        PlayerJump();
        StartGame();
        
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(pauseToggle){

                }
                else{

                }
        
                pauseToggle = !pauseToggle;
            }

       
    }
    
    bool pauseToggle = true;
    // void LateUpdate(){

    //     tempPos = transform.position;
    //     tempPos.y = player.position.y;

    //     if(scenename != "MainMenu")
        
    //         minY += 0.5f * Time.deltaTime;
    //         if(tempPos.y <  minY)
    //             {
    //                Debug.Log("Dead");
    //             }
    //     if(tempPos.y < minY)
    //     tempPos.y = minY;


    //     transform.position = tempPos;
    // }
    public GameObject playerMove;
    public GameObject Close;

    void showLevelComp(){
            playerMove.GetComponent<PlayerMove>().enabled = false;
            Close.SetActive(true);
            Retry.SetActive(true);
            LevelCompleteBG.SetActive(true);
        }

    void FixedUpdate(){
        
    }

    void Player1Movement(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }

 
    void AnimatePlayer(){
        if(movementX > 0){
            PlayerJump();
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }else if(movementX < 0){
            PlayerJump();
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else{
            anim.SetBool(WALK_ANIMATION, false);
        }

    }//Animate

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            anim.SetBool(JUMP_ANIMATION, true);
            if(movementX > 0){
                anim.SetBool(JUMP_ANIMATION, true);
                sr.flipX = false;
            }else if(movementX < 0){
                anim.SetBool(JUMP_ANIMATION, true);
                sr.flipX = true;
            }
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GROUND_TAG) || collision.gameObject.CompareTag("CondGround") 
        || collision.gameObject.CompareTag("CondGround2")         || collision.gameObject.CompareTag("CondGround3")){
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
            player.transform.parent=null;
        
        }
        if(collision.gameObject.CompareTag("movingplatform") ){
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
            player.transform.parent=collision.gameObject.transform;
        }
        if(collision.gameObject.CompareTag(ARROW_TAG)){
            // resultScore.GetComponent<UnityEngine.UI.Text>().text  = points.ToString();
            resultScore.SetActive(true);
            LevelCompleteBG.SetActive(true);
            showLevelComp();
            resultText.SetActive(true);
            // Exit.SetActive(true);
            done = true;
            Destroy(gameObject);
        }
          
        // if(collision.gameObject.CompareTag(UPPLATFORM_TAG)){
        //     Destroy(gameObject);
        // }
    }



    private void OnCollisionExit2D(Collision2D collision){
        
        if(collision.gameObject.CompareTag("movingplatform") ){
            player.transform.parent=null;
        }
          
        // if(collision.gameObject.CompareTag(UPPLATFORM_TAG)){
        //     Destroy(gameObject);
        // }
    }

    private bool toStart = false;
    private bool toLvl1 = false;
    private bool toLvl2 = false;
    private bool toLevels = false;
    
    private bool toMainMenu = false;

    void StartGame(){
        
        if (Input.GetKeyDown(KeyCode.Return) && toStart == true)
        {
            SceneManager.LoadScene("LevelOne");
            Debug.Log("Game Start!");
            Sfxmanager.sfxInstance.Audio.PlayOneShot(Sfxmanager.sfxInstance.Click);
        }
        if (Input.GetKeyDown(KeyCode.Return) && toLvl1 == true)
        {
            SceneManager.LoadScene("LevelOne");
            Debug.Log("Game Start!");
             Sfxmanager.sfxInstance.Audio.PlayOneShot(Sfxmanager.sfxInstance.Click);
        }
        if (Input.GetKeyDown(KeyCode.Return) && toLvl2 == true)
        {
            SceneManager.LoadScene("LevelTwo");
            Debug.Log("Game Start!");
             Sfxmanager.sfxInstance.Audio.PlayOneShot(Sfxmanager.sfxInstance.Click);
        }
        if (Input.GetKeyDown(KeyCode.Return) && toLevels == true)
        {
            SceneManager.LoadScene("LevelSelection");
            Debug.Log("Game Start!");
             Sfxmanager.sfxInstance.Audio.PlayOneShot(Sfxmanager.sfxInstance.Click);
        }if (Input.GetKeyDown(KeyCode.Return) && toMainMenu == true)
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Game Start!");
             Sfxmanager.sfxInstance.Audio.PlayOneShot(Sfxmanager.sfxInstance.Click);
        }
        if (Input.GetKeyDown(KeyCode.Return) && toCredits == true)
        {
            SceneManager.LoadScene("Credits");
             Sfxmanager.sfxInstance.Audio.PlayOneShot(Sfxmanager.sfxInstance.Click);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag(FLOOD_TAG)){
           resultScore.SetActive(true);
            LevelCompleteBG.SetActive(true);
            showLevelComp();
            resultText.SetActive(true);
            // Exit.SetActive(true);
            done = true;
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag(START_TAG)){
            // Destroy(gameObject);
            toStart = true;
            Debug.Log("Start");
        }
        if(collision.gameObject.CompareTag("level1")){
            // Destroy(gameObject);
            toLvl1 = true;
            Debug.Log("Start");
        }
        if(collision.gameObject.CompareTag("level2")){
            // Destroy(gameObject);
            toLvl2 = true;
            Debug.Log("Start");
        }if(collision.gameObject.CompareTag("levels")){
            // Destroy(gameObject);
            toLevels = true;
            Debug.Log("Start");
        }if(collision.gameObject.CompareTag("back")){
            // Destroy(gameObject);
            toMainMenu = true;
            Debug.Log("Start");
        }if(collision.gameObject.CompareTag("credits")){
            // Destroy(gameObject);
            toCredits = true;
            Debug.Log("Start");
        }
    }

    bool toCredits = false;
    private void OnTriggerExit2D(Collider2D collision){
        
        if(collision.gameObject.CompareTag(START_TAG)){
            // Destroy(gameObject);
            toStart = false;
            Debug.Log("Can't Start");
        
        }if(collision.gameObject.CompareTag("level1")){
            // Destroy(gameObject);
            toLvl1 = false;
            Debug.Log("Can't Start");
        }
        if(collision.gameObject.CompareTag("level2")){
            // Destroy(gameObject);
            toLvl2 = false;
            Debug.Log("Can't Start");
        }
        if(collision.gameObject.CompareTag("levels")){
            // Destroy(gameObject);
            toLevels = false;
            Debug.Log("Can't Start");
        }
        if(collision.gameObject.CompareTag("back")){
            toMainMenu = false;
            Debug.Log("Can't Start");
        }
        if(collision.gameObject.CompareTag("credits")){
            toCredits = false;
            Debug.Log("Can't Start");
        }
    }

}
