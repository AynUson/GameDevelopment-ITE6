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

    IEnumerator SpawnTraps(){

        while(true){

            yield return new WaitForSeconds(Random.Range(3,5));
    
            randomIndex = Random.Range(0,trapReference.Length);
            randomSide = Random.Range(0,2);

            spawnedTrap = Instantiate(trapReference[randomIndex]);

            if(randomSide == 0){
                spawnedTrap.transform.position = leftPos.position;
                spawnedTrap.GetComponent<Traps>().speed = Random.Range(4,10);
            }else{
                spawnedTrap.transform.position = rightPos.position;
                spawnedTrap.GetComponent<Traps>().speed = -Random.Range(4,10);
                spawnedTrap.transform.localScale = new Vector3(-0.3003105f,0.3003105f,0.3003105f);
            }
        }


    }



}
