using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform [] spawnPoints;

    // randomly pick a spawn point
    // spawn prefab at spawn point

    void Start()
    {
        SpawnPrefab();
    }

    void SpawnPrefab()
    {
        Instantiate(prefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }
    // Instantiate(prefab, spawnPoints[Random.Range(0, spawnPoints.Length).position], Quaternion.identity);
    // Random.Range(0, spawnPoints.Length);
}
