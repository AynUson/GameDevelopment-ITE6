using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionScript : MonoBehaviour
{

    float currentTime=0f;
    float startingTime=0f;
    public GameObject grounds;
    public GameObject grounds2;
    public GameObject grounds3;
    public GameObject grounds4;
    public GameObject grounds5;
    public GameObject grounds6;
    public GameObject grounds7;
    public GameObject grounds8;
    // level complete
    public GameObject resultText;
    public GameObject resultScore;
    public GameObject LevelCompleteBG;
    public GameObject Retry;
    public GameObject Continue;
    public GameObject Close;
    // level complete
    public GameObject pointText;
    public GameObject TimerText;
    public GameObject Exit;
    private Transform player;
    private Vector3 tempPos;
    private bool q1,q2,q3,q4,q5,q6,q7,q8;
    private int points;
    string[] questions = {"Floods happen when _________", "What does PAGASA stands for?", "Important items to keep in an Emergency kit include:",
     "Why do emergency kits need to be restocked, if they have not been used in a while."};
    string[] q1Answers = {"A. too much snow and winds are present", "B. too much rain in a short period of time", "C. too much rain in mountains"};
    public int num = 5;
    // Image
    public Image questionImg;
    public GameObject ansImg;
    public Sprite q1img;
    public Sprite q1AnsAimg;
    public Sprite q1AnsBimg;
    public Sprite q1AnsCimg;
    public Sprite q2img;
    public Sprite q2AnsAimg;
    public Sprite q2AnsBimg;
    public Sprite q2AnsCimg;
    public Sprite q3img;
    public Sprite q3AnsAimg;
    public Sprite q3AnsBimg;
    public Sprite q3AnsCimg;
    public Sprite q4img;
    public Sprite q4AnsAimg;
    public Sprite q4AnsBimg;
    public Sprite q4AnsCimg;
    public Sprite q5img;
    public Sprite q5AnsAimg;
    public Sprite q5AnsBimg;
    public Sprite q5AnsCimg;
    public Sprite q6img;
    public Sprite q6AnsAimg;
    public Sprite q6AnsBimg;
    public Sprite q6AnsCimg;
    public Sprite q7img;
    public Sprite q7AnsAimg;
    public Sprite q7AnsBimg;
    public Sprite q7AnsCimg;
    public Sprite q8img;
    public Sprite q8AnsAimg;
    public Sprite q8AnsBimg;
    public Sprite q8AnsCimg;


    // Start is called before the first frame update

    public void showhideQuestion(float playerY, float questionY, float disappearY, Sprite question){
        questionImg.sprite = question;
        if(playerY >= questionY && playerY < disappearY){
            questionImg.gameObject.SetActive(true);   
        }else{
            questionImg.gameObject.SetActive(false);  
        }
        
    }

    public void showhideAnswers(Sprite answers){
        ansImg.GetComponent<UnityEngine.UI.Image>().sprite = answers;
        ansImg.gameObject.SetActive(false);  
         if(ansImg){
            ansImg.gameObject.SetActive(true);   
        }else{
            ansImg.gameObject.SetActive(false);   
        }
         
    }
    string scenename = "";
    void Start()
    {   
        currentTime = startingTime;
        Scene scene = SceneManager.GetActiveScene();
        scenename = scene.name;
        pointText.GetComponent<UnityEngine.UI.Text>().text = points.ToString();
        TimerText.GetComponent<UnityEngine.UI.Text>().text = currentTime.ToString();
        player = GameObject.FindWithTag("Player").transform;
        grounds.SetActive(false);
        grounds2.SetActive(false);
        grounds3.SetActive(false);
        resultScore.SetActive(false);
        LevelCompleteBG.SetActive(false);
        Close.SetActive(false);
        Retry.SetActive(false);
        Continue.SetActive(false);
        resultText.SetActive(false);
        grounds4.SetActive(false);
        if(scenename == "LevelTwo"){
            grounds5.SetActive(false);
        grounds6.SetActive(false);
        grounds7.SetActive(false);
        grounds8.SetActive(false);
        }
        
        Exit.SetActive(false);
        ansImg.gameObject.SetActive(false);  
        q1 = false;
        q2 = false;
        q3 = false;
        q4 = false;
        q5 = false;
        q6 = false;
        q7 = false;
        q8 = false;
    }
    

    // Update is called once per frame
    int time = 0;
    bool pauseToggle = false;
    void Update()
    {    if(!done && player != null && !pauseToggle){
            currentTime +=1 * Time.deltaTime;
            time = (int)currentTime;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseToggle = !pauseToggle;
            }
        if(pauseToggle){
            playerMove.GetComponent<PlayerMove>().enabled = false;
        }else{
        
            playerMove.GetComponent<PlayerMove>().enabled = true;
        }

        // playerMove.GetComponent<PlayerMove>().enabled = false;
        TimerText.GetComponent<UnityEngine.UI.Text>().text = time.ToString();
        if((canPick) && Input.GetKeyDown(KeyCode.Return)){
            pickAns();
            
            grounds.SetActive(true);
        }
        tempPos = transform.position;
        tempPos.y = player.position.y;
        tempPos.x = player.position.x;
        // Q1
        if(q1 == false){
            showhideQuestion(tempPos.y, 15.0f, 25.0f, q1img);
        }else if(q1 == true && q2 == false){
            showhideQuestion(tempPos.y, 30.0f, 40.0f, q2img);
        }else if(q1 == true && q2 == true && q3 == false){
            showhideQuestion(tempPos.y, 49.0f, 65.0f, q3img);
        }
        else if(q1 == true && q2 == true && q3 == true && q4 == false){
            showhideQuestion(tempPos.y, 76.0f, 90.0f, q4img);
        }
        else if(q1 == true && q2 == true && q3 == true && q4 == true && q5 == false){
            showhideQuestion(tempPos.y, 100.0f, 115.0f, q5img);
        }
        else if(q1 == true && q2 == true && q3 == true && q4 == true && q5 == true && q6 == false){
            showhideQuestion(tempPos.y, 129.0f, 145.0f, q6img);
        }
        else if(q1 == true && q2 == true && q3 == true && q4 == true && q5 == true && q6 == true && q7 == false){
            showhideQuestion(tempPos.y, 161.0f, 180.0f, q7img);
        }
        else if(q1 == true && q2 == true && q3 == true && q4 == true && q5 == true && q6 == true && q7 == true && q8 == false){
            showhideQuestion(tempPos.y, 197.0f, 215.0f, q8img);
        }


    }


    private bool canPick = false;
    private bool done = false;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Result")){
            // Destroy(gameObject);
            done = true;
            if(scenename == "LevelOne"){
                SceneManager.LoadScene("LevelTwo");
            }else if(scenename == "LevelTwo"){
                SceneManager.LoadScene("MainMenu");
            }
           
        }
        // Question1
        if(collision.gameObject.CompareTag("Q1A1")){
            // Destroy(gameObject);
            showhideAnswers(q1AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q1A2")){
            // Destroy(gameObject);
            showhideAnswers(q1AnsBimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q1A3")){
            // Destroy(gameObject);
            showhideAnswers(q1AnsCimg);
            canPick = true;
            correct = "c";
            
        }
        // Question1
        // Question2
         if(collision.gameObject.CompareTag("Q2A1")){
            // Destroy(gameObject);
            showhideAnswers(q2AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q2A2")){
            // Destroy(gameObject);
            showhideAnswers(q2AnsBimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q2A3")){
            // Destroy(gameObject);
            showhideAnswers(q2AnsCimg);
            canPick = true;
            correct = "c";
            
        }
        // Question2
        // Question3
         if(collision.gameObject.CompareTag("Q3A1")){
            // Destroy(gameObject);
            showhideAnswers(q3AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q3A2")){
            // Destroy(gameObject);
            showhideAnswers(q3AnsBimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q3A3")){
            // Destroy(gameObject);
            showhideAnswers(q3AnsCimg);
            canPick = true;
            correct = "c";
            
        }
        // Question3
        // Question4
         if(collision.gameObject.CompareTag("Q4A1")){
            // Destroy(gameObject);
            showhideAnswers(q4AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q4A2")){
            // Destroy(gameObject);
            showhideAnswers(q4AnsBimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q4A3")){
            // Destroy(gameObject);
            showhideAnswers(q4AnsCimg);
            canPick = true;
            correct = "c";
            
        }
        // Question4
        if(scenename == "LevelTwo"){
// Question5
         if(collision.gameObject.CompareTag("Q5A1")){
            // Destroy(gameObject);
            showhideAnswers(q5AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q5A2")){
            // Destroy(gameObject);
           showhideAnswers(q5AnsAimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q5A3")){
            // Destroy(gameObject);
           showhideAnswers(q5AnsAimg);
            canPick = true;
            correct = "c";  
            
        }
        // Question5
        // Question6
         if(collision.gameObject.CompareTag("Q6A1")){
            // Destroy(gameObject);
            showhideAnswers(q6AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q6A2")){
            // Destroy(gameObject);
           showhideAnswers(q6AnsBimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q6A3")){
            // Destroy(gameObject);
           showhideAnswers(q6AnsCimg);
            canPick = true;
            correct = "c";  
            
        }
        // Question6
        // Question7
         if(collision.gameObject.CompareTag("Q7A1")){
            // Destroy(gameObject);
            showhideAnswers(q7AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q7A2")){
            // Destroy(gameObject);
           showhideAnswers(q7AnsBimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q7A3")){
            // Destroy(gameObject);
           showhideAnswers(q7AnsCimg);
            canPick = true;
            correct = "c";  
            
        }
        // Question7
        // Question8
         if(collision.gameObject.CompareTag("Q8A1")){
            // Destroy(gameObject);
            showhideAnswers(q8AnsAimg);
            canPick = true;
            correct = "a";
            
        }
        if(collision.gameObject.CompareTag("Q8A2")){
            // Destroy(gameObject);
           showhideAnswers(q8AnsBimg);
            canPick = true;
            correct = "b";
            
        }
        if(collision.gameObject.CompareTag("Q8A3")){
            // Destroy(gameObject);
           showhideAnswers(q8AnsCimg);
            canPick = true;
            correct = "c";  
            
        }
        // Question8
        }
        
    }

    private string correct;

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Result")){
            // Destroy(gameObject);
        }
        // Question1
        if(collision.gameObject.CompareTag("Q1A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q1A2")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q1A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question1
         // Question2
         if(collision.gameObject.CompareTag("Q2A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q2A2")){
            // Destroy(gameObject);
           canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q2A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question2
        // Question3
         if(collision.gameObject.CompareTag("Q3A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q3A2")){
            // Destroy(gameObject);
           canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q3A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question3
        // Question4
         if(collision.gameObject.CompareTag("Q4A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q4A2")){
            // Destroy(gameObject);
           canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q4A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question4
        if(scenename == "LevelTwo"){
 // Question5
         if(collision.gameObject.CompareTag("Q5A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q5A2")){
            // Destroy(gameObject);
           canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q5A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question5
        // Question6
         if(collision.gameObject.CompareTag("Q6A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q6A2")){
            // Destroy(gameObject);
           canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q6A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question6
        // Question7
         if(collision.gameObject.CompareTag("Q7A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q7A2")){
            // Destroy(gameObject);
           canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q7A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question7
        // Question8
         if(collision.gameObject.CompareTag("Q8A1")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q8A2")){
            // Destroy(gameObject);
           canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        if(collision.gameObject.CompareTag("Q8A3")){
            // Destroy(gameObject);
            canPick = false;
            correct = "";
            ansImg.gameObject.SetActive(false);  
            
        }
        // Question6
        }
       
    }
    

   
    void pickAns(){
                Sfxmanager.sfxInstance.Audio.PlayOneShot(Sfxmanager.sfxInstance.Pop);
                if(q1 == false){
                    if(correct == "b"){
                    points++;
                    }
                    
                    // GameObject.FindGameObjectWithTag("CondGround").SetActive(false);
                    Destroy(GameObject.FindWithTag("Q1A1"));
                    Destroy(GameObject.FindWithTag("Q1A2"));
                    Destroy(GameObject.FindWithTag("Q1A3"));
               
                    
                    q1 = true;
                }else if(q2 == false){
                    if(correct == "a"){
                    points++;
                    } 
                    grounds2.SetActive(true);
                    Destroy(GameObject.FindWithTag("Q2A1"));
                    Destroy(GameObject.FindWithTag("Q2A2"));
                    Destroy(GameObject.FindWithTag("Q2A3"));
               
                    q2 = true;
                }else if(q3 == false){
                    if(correct == "c"){
                    points++;
                    } 
                    grounds3.SetActive(true);
                    Destroy(GameObject.FindWithTag("Q3A1"));
                    Destroy(GameObject.FindWithTag("Q3A2"));
                    Destroy(GameObject.FindWithTag("Q3A3"));
               
                    q3 = true;
                }else if(q4 == false){
                    if(correct == "c"){
                    points++;
                    } 
                    grounds4.SetActive(true);
                    Destroy(GameObject.FindWithTag("Q4A1"));
                    Destroy(GameObject.FindWithTag("Q4A2"));
                    Destroy(GameObject.FindWithTag("Q4A3"));
                    q4 = true;
                    if(scenename == "LevelOne" ){
                        resultScore.GetComponent<UnityEngine.UI.Text>().text  = points.ToString();
                        resultScore.SetActive(true);
                        LevelCompleteBG.SetActive(true);
                        showLevelComp();
                        resultText.SetActive(true);
                        Exit.SetActive(true);
                        done = true;
                    }
                    
                    
                }else if(q5 == false){
                    if(correct == "c"){
                    points++;
                    } 
                    grounds5.SetActive(true);
                    Destroy(GameObject.FindWithTag("Q5A1"));
                    Destroy(GameObject.FindWithTag("Q5A2"));
                    Destroy(GameObject.FindWithTag("Q5A3"));
               
                    q5 = true;
                }
                else if(q6 == false){
                    if(correct == "c"){
                    points++;
                    } 
                    grounds6.SetActive(true);
                    Destroy(GameObject.FindWithTag("Q6A1"));
                    Destroy(GameObject.FindWithTag("Q6A2"));
                    Destroy(GameObject.FindWithTag("Q6A3"));
               
                    q6 = true;
                } else if(q7 == false){
                    if(correct == "a"){
                    points++;
                    } 
                    grounds7.SetActive(true);
                    Destroy(GameObject.FindWithTag("Q7A1"));
                    Destroy(GameObject.FindWithTag("Q7A2"));
                    Destroy(GameObject.FindWithTag("Q7A3"));
               
                    q7 = true;
                }else if(q8 == false){
                    if(correct == "a"){
                    points++;
                    } 
                    grounds8.SetActive(true);
                    Destroy(GameObject.FindWithTag("Q8A1"));
                    Destroy(GameObject.FindWithTag("Q8A2"));
                    Destroy(GameObject.FindWithTag("Q8A3"));
               
                    q8 = true;
                    resultScore.GetComponent<UnityEngine.UI.Text>().text  = points.ToString();
                    resultScore.SetActive(true);
                    LevelCompleteBG.SetActive(true);
                    showLevelComp();
                    resultText.SetActive(true);
                    Exit.SetActive(true);
                    done = true;
                }
                
                
                pointText.GetComponent<UnityEngine.UI.Text>().text  = points.ToString();
                resultScore.GetComponent<UnityEngine.UI.Text>().text  = points.ToString();
            
    }
    
    public GameObject playerMove;

    void showLevelComp(){
        playerMove.GetComponent<PlayerMove>().enabled = false;
        Continue.SetActive(true);
        Retry.SetActive(true);
        Close.SetActive(true);
        LevelCompleteBG.SetActive(true);
    }





}
