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
    }

    // Update is called once per frame
    void Update()
    {
        

        Player1Movement();
        AnimatePlayer();
        PlayerJump();
        StartGame();
        

    }
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
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
            Debug.Log("Ground Touched!");
        }
        if(collision.gameObject.CompareTag(ARROW_TAG)){
            Destroy(gameObject);
        }
          
        // if(collision.gameObject.CompareTag(UPPLATFORM_TAG)){
        //     Destroy(gameObject);
        // }
    }

    private bool toStart = false;

    void StartGame(){
        
        if (Input.GetKeyDown(KeyCode.Return) && toStart == true)
        {
            SceneManager.LoadScene("LevelOne");
            Debug.Log("Game Start!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag(FLOOD_TAG)){
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag(START_TAG)){
            // Destroy(gameObject);
            toStart = true;
            Debug.Log("Start");
        
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        
        if(collision.gameObject.CompareTag(START_TAG)){
            // Destroy(gameObject);
            toStart = false;
            Debug.Log("Can't Start");
        
        }
    }

}
