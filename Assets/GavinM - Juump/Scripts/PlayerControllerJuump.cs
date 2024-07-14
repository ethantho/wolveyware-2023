using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJuump : MonoBehaviour
{

    public float chargeTime;
    public float jumpPower;
    public float dashSpeed;
    public float walkSpeed;
    public GameObject destroyParticle;
    public GameObject dashParticle;

    public bool onGround = false; //is the player on the ground
    private bool canDash = false; //is the player can dash
    public bool isCharging = false; //is jump being held
    public float currentCharge = 0; //amount of time that jump has been held
    private Rigidbody2D rb;
    private AudioSource[] audioSources; //all audio sources attached to player

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!onGround && canDash && transform.position.y>-2.5f)
            {
                rb.AddForce(Vector3.right * dashSpeed * -1);
                canDash = false;
                audioSources[2].Play();
                Instantiate(dashParticle, transform.position, dashParticle.transform.rotation).GetComponent<Rigidbody2D>().velocity = Vector3.right*4;
            }
            else if (onGround && !isCharging)
            {
                transform.Translate(Vector3.right * walkSpeed * -1 * Time.deltaTime);
                if (!audioSources[4].isPlaying)
                {
                    audioSources[4].Play();
                }
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!onGround && canDash && transform.position.y>-2.5f)
            {
                rb.AddForce(Vector3.right * dashSpeed);
                canDash = false;
                audioSources[2].Play();
                Instantiate(dashParticle,transform.position, dashParticle.transform.rotation).GetComponent<Rigidbody2D>().velocity = Vector3.left*4;
            }
            else if (onGround && !isCharging)
            {
                transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
                if (!audioSources[4].isPlaying)
                {
                    audioSources[4].Play();
                }
            }
        }

        if (isCharging)
        {
            currentCharge += Time.deltaTime;
            if (currentCharge > chargeTime)
            {
                currentCharge = chargeTime;
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && onGround)
        {
            isCharging=true;
            currentCharge = chargeTime / 2;
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W)) && isCharging)
        {
            isCharging=false;
            rb.AddForce(Vector3.up * jumpPower * currentCharge / chargeTime);
            currentCharge = 0;

            if (currentCharge >= chargeTime)
            {
                audioSources[1].Play();
            }
            else
            {
                audioSources[0].Play();
            }
        }

        if (!onGround)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,(Mathf.Atan2(rb.velocity.y,rb.velocity.x) * Mathf.Rad2Deg - 90)%180));
        }else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            audioSources[3].Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
            canDash = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            GameObject newParticle = Instantiate(destroyParticle, transform.position, destroyParticle.transform.rotation);
            newParticle.GetComponent<Rigidbody2D>().velocity = rb.velocity*0.3f + Vector2.up*3;
            GameObject.Find("Game Manager").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            MinigameManager.MinigameFailure();
        }
    }
}
