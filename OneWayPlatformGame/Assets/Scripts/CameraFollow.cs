using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    string scenename = "";
    private Transform player;
    private Vector3 tempPos;
    
    [SerializeField]
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        player = GameObject.FindWithTag("Player").transform;
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        scenename = scene.name;

    }

    // Update is called once per frame
    void LateUpdate()
    {   

        if(player == null){
            SceneManager.LoadScene("MainMenu");
            return;
        }
            

        tempPos = transform.position;
        tempPos.y = player.position.y;
        tempPos.x = player.position.x;

        if(tempPos.x < minX)
            tempPos.x = minX;

        if(tempPos.x > maxX)
            tempPos.x = maxX;

        if(scenename != "MainMenu")
            
            minY += 0.5f * Time.deltaTime;
            if(tempPos.y <  minY)
                {
                   //destroy player
                }
        if(tempPos.y < minY)
        tempPos.y = minY;

        if(tempPos.y > maxY)
            tempPos.y = maxY;

        transform.position = tempPos;
    }




}//Classs











