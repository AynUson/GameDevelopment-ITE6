using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    
    public float moveForce = 10f;
    public float jumpForce = 11f;
    
    public float movementX;
    public Rigidbody2D myBody;
    public Animator anim;
    public string WALK_ANIMATION = "Walk";
    public string GROUND_TAG = "Ground";
    public string START_TAG = "Start";
    
    private string ARROW_TAG = "ArrowTrap";
    public SpriteRenderer sr;
    public bool isGrounded; 
    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Player1Movement();
        AnimatePlayer();
        PlayerJump();
        StartGame();
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");

        // Vector2 pos= transform.position;

        // pos.x += h * speed * Time.deltaTime;
        // pos.y += v * speed * Time.deltaTime;

        // transform.position = pos; 

    }

    void FixedUpdate(){
        
    }

    void Player1Movement(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }

 
    void AnimatePlayer(){
        if(movementX > 0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }else if(movementX < 0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else{
            anim.SetBool(WALK_ANIMATION, false);
        }

    }//Animate

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
            Debug.Log("Ground Touched!");
        }
        if(collision.gameObject.CompareTag(ARROW_TAG)){
            Destroy(gameObject);
        }
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
