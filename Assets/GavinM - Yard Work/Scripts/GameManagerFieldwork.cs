using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFieldwork : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject boxPrefab;
    public GameObject zonePrefab;

    public GameObject[] decorations;
    public int decorationCount;

    GameObject zone1;
    GameObject zone2;

    GameObject Box1;
    GameObject Box2;
    void Start()
    {
        Box1 = Instantiate(boxPrefab, new Vector2(-3, 0), boxPrefab.transform.rotation);
        Box2 = Instantiate(boxPrefab, new Vector2(3, 0), boxPrefab.transform.rotation);

        zone1 = Instantiate(zonePrefab, new Vector3(Random.Range(-2, 7), 3, 1), zonePrefab.transform.rotation);
        zone2 = Instantiate(zonePrefab, new Vector3(Random.Range(-7, 2), -3, 1), zonePrefab.transform.rotation);

        for (int i=0;i<decorationCount;i++)
        {
            int randInd = Random.Range(0,decorations.Length);
            Instantiate(decorations[randInd], new Vector3(Random.Range(-11, 11), Random.Range(-6, 6), 1.5f), decorations[randInd].transform.rotation);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (zone1.GetComponent<CheckCompleteFieldwork>().isFilled &&  zone2.GetComponent<CheckCompleteFieldwork>().isFilled)
        {
            MinigameManager.MinigameSuccess();
        }
    }
}
