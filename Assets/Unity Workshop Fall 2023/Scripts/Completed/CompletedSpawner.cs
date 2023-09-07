using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedSpawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public Transform spawnLocation;
    public float spawnInterval = 1f;
    public bool isSpawning;
    float nextSpawnTime = 0f;
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    
    void SpawnObject()
    {
        Instantiate(objToSpawn, spawnLocation.position, spawnLocation.rotation);
    }
}
