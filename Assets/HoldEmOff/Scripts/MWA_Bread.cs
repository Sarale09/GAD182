using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Bread : MonoBehaviour
{
    [SerializeField]
    private int health = 100; // Starting health of the bread

    [SerializeField]
    private Sprite fullBreadSprite; // Sprite for full health
    [SerializeField]
    private Sprite fourOutOfFiveBreadSprite; // Sprite for 80% health
    [SerializeField]
    private Sprite threeOutOfFiveBreadSprite; // Sprite for 60% health
    [SerializeField]
    private Sprite twoOutOfFiveBreadSprite; // Sprite for 40% health
    [SerializeField]
    private Sprite oneOutOfFiveBreadSprite; // Sprite for 20% health

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    public TextMeshProUGUI gameOverText; // Drag and drop your TextMeshPro element

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite(); // Set the initial sprite based on starting health
    }

    // Method to reduce health
    public void ReduceHealth(int amount)
    {
        health -= amount;

        UpdateSprite(); // Update the sprite based on new health

        // Check if health has reached zero
        if (health <= 0)
        {
            health = 0;
            OnBreadConsumed();
        }
    }

    // Method to update the bread sprite based on health
    private void UpdateSprite()
    {
        if (health <= 80 && health >= 61)
            spriteRenderer.sprite = fourOutOfFiveBreadSprite;
        else if (health <= 60 && health >= 41)
            spriteRenderer.sprite = threeOutOfFiveBreadSprite;
        else if (health <= 40 && health >= 21)
            spriteRenderer.sprite = twoOutOfFiveBreadSprite;
        else if (health <= 20 && health >= 1)
            spriteRenderer.sprite = oneOutOfFiveBreadSprite;
        else
            spriteRenderer.sprite = fullBreadSprite;
    }

    // Called when bread's health reaches zero
    private void OnBreadConsumed()
    {
        // Show "GAME OVER" text
        gameOverText.gameObject.SetActive(true);

        // Destroy the bread object
        Destroy(gameObject);

        // Destroy the swatter if it exists
        GameObject swatter = GameObject.FindWithTag("Swatter");
        if (swatter != null)
        {
            Destroy(swatter);
        }

        // Destroy all insects and insect spawners
        GameObject[] insects = GameObject.FindGameObjectsWithTag("Insect");
        foreach (GameObject insect in insects)
        {
            Destroy(insect);
        }
        GameObject[] insectSpawners = GameObject.FindGameObjectsWithTag("InsectSpawner");
        foreach (GameObject insectSpawner in insectSpawners)
        {
            Destroy(insectSpawner);
        }
    }


}
