using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour
{
    SpriteRenderer spr;
    [SerializeField] Sprite punching;
    [SerializeField] Sprite notPunching;
    CircleCollider2D punchCol;
    bool canPunch;

    // Start is called before the first frame update
    void Start()
    {

        spr = GetComponent<SpriteRenderer>();

        spr.sprite = notPunching;

        punchCol = GetComponent<CircleCollider2D>();

        punchCol.enabled = false;

        canPunch = true;

        GetComponent<AudioSource>().pitch = Time.timeScale / 1.333f;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canPunch)
        {
            StartCoroutine(Punch());
        }
    }

    IEnumerator Punch()
    {
        spr.sprite = punching;
        punchCol.enabled = true;
        yield return new WaitForSeconds(0.3f);


        spr.sprite = notPunching;
        punchCol.enabled = false;
        canPunch = false;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            collision.GetComponent<FireballController>().vel *= -10f;
        }
    }
}
