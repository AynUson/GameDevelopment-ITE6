using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class buttonHandler : MonoBehaviour
{
    public GameObject resultText;
    public GameObject resultScore;
    public GameObject LevelCompleteBG;
    public GameObject Retry;
    public GameObject Continue;
    public GameObject playerMove;
    public GameObject Close;
    
    public GameObject CloseFailed;
    string scenename = "";

    
     void Start()
    {
        
        Scene scene = SceneManager.GetActiveScene();
        scenename = scene.name;

    }
   public void close(){
       
        playerMove.GetComponent<PlayerMove>().enabled = true;
        resultScore.SetActive(false);
        LevelCompleteBG.SetActive(false);
        Close.SetActive(false);
        Retry.SetActive(false);
        Continue.SetActive(false);
        resultText.SetActive(false);
   }
   public void closefailed(){
       
     //    playerMove.GetComponent<PlayerMove>().enabled = true;
        resultScore.SetActive(false);
        LevelCompleteBG.SetActive(false);
        Close.SetActive(false);
        Retry.SetActive(false);
        Continue.SetActive(false);
        resultText.SetActive(false);
        SceneManager.LoadScene("MainMenu");
   }

   public void toMainmenu(){
       
     
        SceneManager.LoadScene("MainMenu");
   }



   public void retry(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerMove.GetComponent<PlayerMove>().enabled = true;
        resultScore.SetActive(false);
        LevelCompleteBG.SetActive(false);
        Close.SetActive(false);
        Retry.SetActive(false);
        Continue.SetActive(false);
        resultText.SetActive(false);
   }
   
   public void nextLevel(){
        if(scenename == "LevelOne"){
          SceneManager.LoadScene("LevelTwo");
          playerMove.GetComponent<PlayerMove>().enabled = true;
          resultScore.SetActive(false);
          LevelCompleteBG.SetActive(false);
          Close.SetActive(false);
          Retry.SetActive(false);
          Continue.SetActive(false);
          resultText.SetActive(false);
        }else if(scenename == "LevelTwo"){
          SceneManager.LoadScene("MainMenu");
          playerMove.GetComponent<PlayerMove>().enabled = true;
        }
        
   }
}
