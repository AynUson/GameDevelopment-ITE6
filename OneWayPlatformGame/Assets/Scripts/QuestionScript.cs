using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public GameObject Text;
    private Transform player;
    private Vector3 tempPos;
    private bool q1,q2,q3,q4;
    string[] questions = {"Floods happen when _________", "What does PAGASA stands for?", "Important items to keep in an Emergency kit include:",
     "Why do emergency kits need to be restocked, if they have not been used in a while."};
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

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    

    // Update is called once per frame
    void Update()
    {   pickAns();
        tempPos = transform.position;
        tempPos.y = player.position.y;
        tempPos.x = player.position.x;
        // Q1
        if(q1 == false){
            showhideQuestion(tempPos.y, 15.0f, 25.0f, questions[0]);
        }else if(q2 == false){
            showhideQuestion(tempPos.y, 30.0f, 40.0f, questions[1]);
        }


    }

    
    void pickAns(){
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(q1 == false){
                q1 = true;
            }else if(q2 == false){
                q2 = true;
        }
        }
    }







}
