using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpsound : MonoBehaviour
{
    //more sfx stuff
    public AudioSource source;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.W))
      {
        source.PlayOneShot(clip);
      } 
    }
}
