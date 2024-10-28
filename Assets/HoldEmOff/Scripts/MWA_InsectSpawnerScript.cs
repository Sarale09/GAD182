using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_InsectSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject insectPrefab;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    private float timeUntilSpawn;
    
    void Awake()
    {
        SetTimeUntilSpawn(); 
    }

    
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0) 
        { 
            Instantiate(insectPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
