using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_LeftSpawner : MonoBehaviour
{
    public GameObject villager1;
    public NW_Counter counter;

    public float spawnInterval;
    public float timer;
    public float peopleCount;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = FindObjectOfType<NW_Counter>();

        //Instantiate(villager1, new Vector2(-10.5f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval = Random.Range(0, 3);
        
        timer -= Time.deltaTime;
        if (timer <= 0 && counter.fliers > 0 && peopleCount < 5)
        {
            SpawnVillager();
            timer = spawnInterval;
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(villager1, new Vector2(-10.5f, 0), Quaternion.identity);
        }
    }

    void SpawnVillager()
    {
        Instantiate(villager1, new Vector2(-10.5f, 0), Quaternion.identity);
    }
}
