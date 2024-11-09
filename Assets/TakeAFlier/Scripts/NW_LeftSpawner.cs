using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NW_LeftSpawner : MonoBehaviour
{
    public GameObject villager1;
    public NW_Counter counter;

    public float spawnInterval;
    public float timer;
    public float peopleCount;
    
    public float timeRemain = 5f;
    public TextMeshProUGUI timerUI;
    public bool timerEnd;

    public bool gameEnded;
    
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
        
        timerUI.text = "" + (int)timeRemain;

        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;

        }

        if (timeRemain <= 0 )
        {
            timerEnd = true;
        }
        else
        {
            timerEnd = false;
        }

        if (!timerEnd)
        {
            // Spawns villagers at random intervals only if there are less than 5 on the screen and some fliers remain.
            timer -= Time.deltaTime;
            if (timer <= 0 && counter.fliers > 0 && peopleCount < 5)
            {
                SpawnVillager();
                timer = spawnInterval;
            }
        }

        // If the timer has ended or all the fliers are gone before the game ends
        if ((timerEnd || counter.fliers <= 0) && !gameEnded)
        {
            Debug.Log("The time is up.");

            if (counter.fliers == 0)
            {
                Debug.Log("You handed out all the fliers in time!");
                Debug.Log("You win!");
                gameEnded = true;
                timeRemain = 0f;
            }
            else
            {
                Debug.Log("You failed to hand out all the fliers in time...");
                Debug.Log("You failed.");
                gameEnded = true;
            }
        }
        
        
        
        // For testing purposes
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
