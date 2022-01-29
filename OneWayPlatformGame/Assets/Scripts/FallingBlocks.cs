using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
	float speed = 7;
    private Rigidbody2D myBody;
    // private void OnTriggerEnter2D(Collider2D collision){
    //     if(collision.CompareTag("Collector")){
    //         Destroy(collision.gameObject);
    //     }
    // }

    // private void OnCollisionEnter2D(Collider2D collision){
    //     if(collision.CompareTag("Collector")){
    //         Destroy(collision.gameObject);
    //     }
    // }
    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void Update () {
		transform.Translate (Vector3.down * speed * Time.deltaTime, Space.Self);
	}
}
