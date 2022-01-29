using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfxmanager : MonoBehaviour
{
   public AudioSource Audio;
   public AudioClip Click;
   public AudioClip Pop;

   public static Sfxmanager sfxInstance;

    private void Awake(){
        if(sfxInstance != null && sfxInstance !=this)
          {
              Destroy(this.gameObject);
              return;
          }  
          sfxInstance = this;
          DontDestroyOnLoad(this);

    }
}
