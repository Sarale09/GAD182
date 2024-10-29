using System.Collections;
using UnityEngine;

public class Bread : MonoBehaviour
{
    public int health = 10;
    private int insectCount = 0; // Counter for the number of insects
    private float eatTimer = 0f; // Timer to track 1-second intervals

    private void Update()
    {
        if (insectCount > 0 && health > 0) // Check if there are insects eating
        {
            eatTimer += Time.deltaTime;

            // Reduce health every second for each insect
            if (eatTimer >= 1f)
            {
                health -= insectCount; // Decrease health based on number of insects
                eatTimer = 0f; // Reset the timer

                Debug.Log("Health reduced. Current health: " + health); // Debug log for health

                if (health <= 0)
                {
                    Debug.Log("The bread has been fully eaten!");
                    health = 0; // Ensure health doesn't go negative
                }
            }
        }
    }
    public void ReduceBreadHealth()
    {
        health -= health;
    }

}
