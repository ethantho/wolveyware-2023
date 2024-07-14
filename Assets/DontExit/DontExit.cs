using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontExit : MonoBehaviour
{
    float remaining = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remaining -= Time.deltaTime;

        if(0 >= remaining)
        {
            Debug.Log("succeeding");
            MinigameManager.MinigameSuccess();
        }
    }
}
