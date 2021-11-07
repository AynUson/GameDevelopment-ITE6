using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public GameObject Text;
    public Text Answer;
    private Transform player;
    private Vector3 tempPos;
    private bool q1,q2,q3,q4;
    private int points;
    string[] questions = {"Floods happen when _________", "What does PAGASA stands for?", "Important items to keep in an Emergency kit include:",
     "Why do emergency kits need to be restocked, if they have not been used in a while."};
    string[] q1Answers = {"A. too much snow and winds are present", "B. too much rain in a short period of time", "C. too much rain in mountains"};
    public int num = 5;
    // Start is called before the first frame update

    public void showhideQuestion(float playerY, float questionY, float disappearY, string question){
        Text.GetComponent<UnityEngine.UI.Text>().text = question;
        if(playerY >= questionY && playerY < disappearY){
            Text.gameObject.SetActive(true);   
        }else{
            Text.gameObject.SetActive(false);  
        }
        
    }

    public void showhideAnswers(string answers){
        Answer.GetComponent<UnityEngine.UI.Text>().text = answers;
         if(Answer){
            Answer.gameObject.SetActive(true);   
        }
         
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        showhideAnswers(null);
        q1 = false;
        q2 = false;
        q3 = false;
        q4 = false;
    }
    

    // Update is called once per frame
    void Update()
    {   
        if(canPick && Input.GetKeyDown(KeyCode.Return)){
            pickAns();
        }
        tempPos = transform.position;
        tempPos.y = player.position.y;
        tempPos.x = player.position.x;
        // Q1
        if(q1 == false){
            showhideQuestion(tempPos.y, 15.0f, 25.0f, questions[0]);
        }else if(q1 == true && q2 == false){
            showhideQuestion(tempPos.y, 30.0f, 40.0f, questions[1]);
        }


    }


    private bool canPick = false;
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.CompareTag("Q1A1")){
            // Destroy(gameObject);
            showhideAnswers(q1Answers[0]);
            canPick = true;
            Debug.Log(q1Answers[0]);
            
        }
        if(collision.gameObject.CompareTag("Q1A2")){
            // Destroy(gameObject);
            showhideAnswers(q1Answers[1]);
            canPick = true;
            correct = "";
            Debug.Log(correct);
            
        }
        if(collision.gameObject.CompareTag("Q1A3")){
            // Destroy(gameObject);
            showhideAnswers(q1Answers[2]);
            canPick = true;
            Debug.Log(q1Answers[2]);
            
        }
    }

    private string correct;

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Q1A1")){
            // Destroy(gameObject);
            canPick = false;
            showhideAnswers(null);
            Debug.Log("Can't pick");
            
        }
        if(collision.gameObject.CompareTag("Q1A2")){
            // Destroy(gameObject);
            canPick = false;
            correct = "b";
            showhideAnswers(null);
            Debug.Log("Can't pick");
            
        }
        if(collision.gameObject.CompareTag("Q1A3")){
            // Destroy(gameObject);
            canPick = false;
            showhideAnswers(null);
            Debug.Log("Can't pick");
            
        }
        
    }
    

   
    void pickAns(){
        
                Debug.Log("Picked");
                
                if(q1 == false){
                Destroy(GameObject.FindWithTag("Q1A1"));
                Destroy(GameObject.FindWithTag("Q1A2"));
                Destroy(GameObject.FindWithTag("Q1A3"));
                if(correct == "b"){
                points++;
                }
                Debug.Log(points);
                q1 = true;
                Debug.Log(correct);
                }else if(q2 == false){
                    q2 = true;
                }
            
    }







}
