using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sealtouch : MonoBehaviour
    //sfx stuff/heart
{   public AudioSource source;
    public AudioClip clip;
    public GameObject Heart;

    // Looking for a trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        // What was the triggered object?
        GameObject triggedObject = collision.gameObject;

        // If the object has the tag "MSeal"
        if(triggedObject.CompareTag("MSeal"))
        {
// Send a debug log, finish minigame, play clip, show heart. 
Debug.Log("SealTouch");
source.PlayOneShot(clip);
Instantiate(Heart, new Vector3(6, 0, -7), Quaternion.identity);
MinigameManager.MinigameSuccess();

            }
    }
}

