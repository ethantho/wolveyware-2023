using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSlideFieldwork : MonoBehaviour
{

    public float speedCap;
    public float maxVolume;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (audioSource.time > 0.65f && audioSource.pitch == 1)
        {
            audioSource.pitch = -1;
        }
        else if (audioSource.time < 0.4f && audioSource.pitch == -1)
        {
            audioSource.pitch = 1;
        }

        audioSource.volume = (rb.velocity.magnitude / speedCap) * maxVolume / 100;
        if (audioSource.volume > maxVolume)
        {
            audioSource.volume = maxVolume;
        }
    }
}
