using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoaiDeath : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion.SetActive(false);
        GetComponent<AudioSource>().pitch = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FireballController>())
        {
            if(collision.gameObject.GetComponent<FireballController>().vel.x > 0)
            {
                Die();
                Destroy(collision.gameObject);
            }
        }
    }

    void Die()
    {
        //Debug.Log("Enemy Killed");
        explosion.SetActive(true);
        GetComponent<AudioSource>().Play();
        MinigameManager.MinigameSuccess();
       

    }
}
