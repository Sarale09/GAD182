using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bread : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private Sprite fullBreadSprite;
    [SerializeField]
    private Sprite fourOutOfFiveBreadSprite;
    [SerializeField]
    private Sprite threeOutOfFiveBreadSprite;
    [SerializeField]
    private Sprite twoOutOfFiveBreadSprite;
    [SerializeField]
    private Sprite oneOutOfFiveBreadSprite;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText; // UI text to display the timer

    private float timeRemaining = 60f; // 60-second timer
    private bool gameEnded = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    private void Update()
    {
        if (!gameEnded)
        {
            UpdateTimer();
        }
    }

    // Timer countdown
    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time remaining: " + Mathf.CeilToInt(timeRemaining).ToString() + " sec";
        }
        else
        {
            gameEnded = true;
            if (health > 0)
            {
                DisplayWinMessage(); // Win if time runs out and bread still has health
            }
            else
            {
                OnBreadConsumed(); // Lose if bread is fully eaten
            }
        }
    }

    // Method to reduce health
    public void ReduceHealth(int amount)
    {
        if (gameEnded) return;

        health -= amount;
        UpdateSprite();

        if (health <= 0)
        {
            health = 0;
            gameEnded = true;
            OnBreadConsumed(); // Trigger loss if bread is fully eaten
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
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "RIP bread"; // Display losing message
        timerText.text = "";
        DestroyGameObjects();
    }

    // Display win message if timer runs out with bread remaining
    private void DisplayWinMessage()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Victory!"; // Display winning message
        timerText.text = "";
        DestroyGameObjects();
    }

    // Destroys game objects when game ends
    private void DestroyGameObjects()
    {
        Destroy(gameObject); // Destroy the bread

        GameObject swatter = GameObject.FindWithTag("Swatter");
        if (swatter != null)
        {
            Destroy(swatter);
        }

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
