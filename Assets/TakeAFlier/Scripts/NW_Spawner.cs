using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NW_Spawner : MonoBehaviour
{
    public GameObject villager1;
    public NW_Counter counter;

    public List<Vector2> villager1SpawnPoints;

    public float spawnInterval;
    public float timer;
    public float peopleCount;
    public int randomNumber;
    
    public float timeRemain = 50f;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI flierCountText;
    public GameObject resultScreen;
    public GameObject timerCanvas;
    public bool timerEnd;

    public bool gameEnded;
    
    // Start is called before the first frame update
    void Start()
    {
        resultScreen.SetActive(false);
        counter = FindObjectOfType<NW_Counter>();
        
        villager1SpawnPoints.Add(new Vector2(-10.5f, -0.5f));
        villager1SpawnPoints.Add(new Vector2(-10.5f, -1));
        villager1SpawnPoints.Add(new Vector2(10.5f, -0.5f));
        villager1SpawnPoints.Add(new Vector2(10.5f, -1));

        //Instantiate(villager1, new Vector2(-10.5f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0, 5);
        spawnInterval = Random.Range(0, 3);

        timerUI.text = "" + (int)timeRemain;
        flierCountText.text = "Fliers remaining: " + (int)counter.fliers;

        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;

        }

        if (timeRemain <= 0 )
        {
            timerEnd = true;
            resultScreen.SetActive(true);
            timerCanvas.SetActive(false);
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
            timerCanvas.SetActive(false);

            if (counter.fliers == 0)
            {
                Debug.Log("You handed out all the fliers in time!");
                Debug.Log("You win!");

                resultText.text = "You handed out all the fliers in time! You win!";
                
                gameEnded = true;
                timeRemain = 0f;
            }
            else
            {
                Debug.Log("You failed to hand out all the fliers in time...");
                Debug.Log("You failed.");
                
                resultText.text = "You failed to hand out all the fliers in time. You lose.";
                
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
        // needs to instantiate randomly on both sides
        Instantiate(villager1, villager1SpawnPoints[randomNumber], Quaternion.identity);
    }
}
