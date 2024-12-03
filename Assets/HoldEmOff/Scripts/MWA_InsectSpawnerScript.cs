using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_InsectSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] insectPrefabs; // Array to hold different insect prefabs

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
            SpawnRandomInsect();
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void SpawnRandomInsect()
    {
        // Choose a random insect prefab from the array
        int randomIndex = Random.Range(0, insectPrefabs.Length);
        GameObject selectedInsect = insectPrefabs[randomIndex];

        // Instantiate the randomly selected insect
        Instantiate(selectedInsect, transform.position, Quaternion.identity);
    }
}
