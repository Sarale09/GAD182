using System.Collections;
using UnityEngine;

public class Bread : MonoBehaviour
{
    [SerializeField]
    private int health = 10; // Starting health of the bread

    // Method to reduce health
    public void ReduceHealth(int amount)
    {
        health -= amount;
        Debug.Log("Bread health reduced by " + amount + ". Current health: " + health);

        // Check if health has reached zero
        if (health <= 0)
        {
            health = 0;
            OnBreadConsumed();
        }
    }

    // Called when bread's health reaches zero
    private void OnBreadConsumed()
    {
        Debug.Log("Bread has been fully consumed!");
        // Optionally, destroy the bread or trigger an event
        Destroy(gameObject);
    }

    // Getter for health if you need to access the current health value elsewhere
    public int GetHealth()
    {
        return health;
    }
}

