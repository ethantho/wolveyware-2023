using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnPulseJuump : MonoBehaviour
{

    public float lifeTime = 2;

    private SpriteRenderer sr;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 1, 1, 0);
        Invoke("RemoveSelf", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        sr.color = new Color(1, 1, 1, 0.5f - Mathf.Cos((time / lifeTime) * (4*Mathf.PI))/2);
    }

    private void RemoveSelf()
    {
        Destroy(gameObject);
    }
}
