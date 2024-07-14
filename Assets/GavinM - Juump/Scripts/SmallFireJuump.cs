using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFireJuump : MonoBehaviour
{
    public Sprite[] sprites;
    public float cycleTime;

    private SpriteRenderer sr;
    private int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating("SetNewSprite", 0, cycleTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetNewSprite()
    {
        current = (current + Random.Range(1,sprites.Length))%sprites.Length;
        sr.sprite = sprites[current];
    }
}
