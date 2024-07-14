using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float chargeUpTime;
    public Vector3 vel;
    void Start()
    {
        StartCoroutine(ChargeUp());
        vel = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vel * Time.deltaTime;
    }

    IEnumerator ChargeUp()
    {
        float timeElapsed = 0f;
        transform.localScale *= 0.1f;
        while(timeElapsed < chargeUpTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.27f, 0.27f, 0.27f), (timeElapsed / chargeUpTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Launch());
        yield return null;
    }

    IEnumerator Launch()
    {
        vel = new Vector3(-1f, -0.03f);
        vel *= 3f;
        yield return null;
    }


}
