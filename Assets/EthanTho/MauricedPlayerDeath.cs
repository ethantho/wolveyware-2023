using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MauricedPlayerDeath : MonoBehaviour
{
    [SerializeField] UnityEngine.Video.VideoPlayer vp;
    [SerializeField] TextMeshProUGUI help;
    // Start is called before the first frame update
    void Start()
    {
        vp.enabled = false;
        help.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FireballController>())
        {
            Die();
        }
    }

    void Die()
    {
        help.enabled = false;
        vp.enabled = true;
        vp.playbackSpeed = Time.timeScale;
        //MinigameManager.MinigameFailure();
    }
}
