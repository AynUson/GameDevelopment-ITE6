using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    public string FLOOD_TAG = "Flood";
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        rb.velocity = new Vector2 (0f, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
      
        // if(collision.gameObject.CompareTag(UPPLATFORM_TAG)){
        //     Destroy(gameObject);
        // }
    }
}
