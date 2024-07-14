using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControllerJuump : MonoBehaviour
{

    public Sprite[] idleSprites; // sprites the player will cycle between on the ground
    public float idleCycle;

    public Sprite[] stretchSprites; // sprites that will change based on air speed
    public float maxStretchSpeed;

    public Sprite[] squishSprites; // sprites that will change depending on jump charge time
    public Sprite flashSprite;
    public float flashRate;

    private PlayerControllerJuump pc; // retrieving jump charge time
    private SpriteRenderer sr;
    private Rigidbody2D rb; // retrieve movement speed

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerControllerJuump>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isCharging)
        {
            if (pc.currentCharge >= pc.chargeTime)
            {
                if (Time.timeSinceLevelLoad%flashRate > flashRate/2)
                {
                    sr.sprite = flashSprite;
                }
                else
                {
                    sr.sprite = squishSprites[squishSprites.Length-1];
                }
            }
            else
            {
                sr.sprite = squishSprites[(int)(pc.currentCharge / pc.chargeTime * squishSprites.Length)];
            }
        }
        else if (pc.onGround)
        {
            if (Time.timeSinceLevelLoad % idleCycle > idleCycle / 2)
            {
                sr.sprite = idleSprites[0];
            }
            else
            {
                sr.sprite = idleSprites[1];
            }
        }
        else
        {
            for (int i=0;i<stretchSprites.Length;i++)
            {
                if(rb.velocity.magnitude / maxStretchSpeed * stretchSprites.Length > i)
                {
                    sr.sprite = stretchSprites[i];
                }
            }
        }
    }
}
