using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
	public GameObject fallingBlockPrefab;
	public float secondsBetweenSpawns = 1;
	float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start () {
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect, Camera.main.aspect);
	}
	
	// Update is called once per frame
    bool pauseToggle = false;
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseToggle = !pauseToggle;
            }
        if(!pauseToggle){
			if (Time.time > nextSpawnTime) {
				nextSpawnTime = Time.time + secondsBetweenSpawns;

				float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
				float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
				Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), 100 + spawnSize);
				GameObject newBlock = (GameObject)Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
				newBlock.transform.localScale = Vector2.one * spawnSize;
			}
        }
		
	
	}
}
