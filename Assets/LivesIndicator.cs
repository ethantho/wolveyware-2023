using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesIndicator : MonoBehaviour
{
    TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ModeManager.Instance.isBlitzMode)
        {
            txt.text = "Lives: " + ModeManager.Instance.lives;
        }
        else
        {
            txt.text = "";
        }
        
    }
}
