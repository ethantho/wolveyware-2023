using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerJuump : MonoBehaviour
{

    public GameObject fireBall;
    public GameObject warning;

    public float fireBallOffset;
    public float roundDelay;
    public float rounds = 3;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunRounds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRound()
    {
        int randomWave = Random.Range(0, 5);
        for (int i=0;i<=6;i++)
        {
            if (i!=randomWave && i!=randomWave+1 && i!=randomWave+2)
            {
                Instantiate(warning, new Vector3(8, 4 - 1.2f * i, 2), warning.transform.rotation);
                Instantiate(fireBall, new Vector3(8 + fireBallOffset, 4 - 1.2f * i, 2), fireBall.transform.rotation);
            }
        }
    }

    IEnumerator RunRounds()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i=0;i<rounds;i++)
        {
            SpawnRound();
            yield return new WaitForSeconds(roundDelay);
        }
    }
}
