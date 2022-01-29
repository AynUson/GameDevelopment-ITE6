using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trapReference;

    private GameObject spawnedTrap;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTraps());
    }
    bool pauseToggle = false;
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseToggle = !pauseToggle;
            if(!pauseToggle){
            StartCoroutine(SpawnTraps());
        }
        }
        
    }
    IEnumerator SpawnTraps(){
            
        while(!pauseToggle){

            yield return new WaitForSeconds(Random.Range(5,5));
    
            randomIndex = Random.Range(0,trapReference.Length);
            randomSide = Random.Range(0,2);

            spawnedTrap = Instantiate(trapReference[randomIndex]);

            if(randomSide == 0){
                spawnedTrap.transform.position = leftPos.position;
                spawnedTrap.GetComponent<Traps>().speed = Random.Range(4,6);
            }else{
                spawnedTrap.transform.position = rightPos.position;
                spawnedTrap.GetComponent<Traps>().speed = -Random.Range(4,10);
                spawnedTrap.transform.localScale = new Vector3(-0.3003105f,0.3003105f,0.3003105f);
            }
        }


    }



}
