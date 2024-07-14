using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompleteFieldwork : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isFilled = false;
    public ParticleSystem particle;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            isFilled = true;
            Instantiate(particle, transform.position + transform.forward*-3, particle.transform.rotation);
            audioSource.Play();
        }
    }
}
