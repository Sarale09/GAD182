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
    private Sprite ninetyPercentBreadSprite;
    [SerializeField]
    private Sprite eightyPercentBreadSprite;
    [SerializeField]
    private Sprite seventyPercentBreadSprite;
    [SerializeField]
    private Sprite sixtyPercentBreadSprite;
    [SerializeField]
    private Sprite fiftyPercentBreadSprite;
    [SerializeField]
    private Sprite fortyPercentBreadSprite;
    [SerializeField]
    private Sprite thirtyPercentBreadSprite;
    [SerializeField]
    private Sprite twentyPercentBreadSprite;
    [SerializeField]
    private Sprite tenPercentBreadSprite;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText; // UI text to display the timer

    private float timeRemaining = 60f; // 60-second timer
    private bool gameEnded = false;

    public AudioClip audioClip1; // Assign in the inspector
    public AudioClip audioClip2; // Assign in the inspector
    public AudioSource audioSource; // Assign an AudioSource component in the inspector
    private bool playFirstClip = true; // Flag to alternate clips

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
            if (Mathf.FloorToInt(timeRemaining) % 2 == 1 && playFirstClip) // Alternate on odd seconds
            {
                PlayClip(audioClip1);
                playFirstClip = false;
            }
            else if (Mathf.FloorToInt(timeRemaining) % 2 == 0 && !playFirstClip) // Alternate on even seconds
            {
                PlayClip(audioClip2);
                playFirstClip = true;
            }
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
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
    private void PlayClip(AudioClip clip)
    {
        if (audioSource.isPlaying) return; // Prevent overlapping
        audioSource.clip = clip;
        audioSource.Play();
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
        if (health <= 90 && health >= 81)
            spriteRenderer.sprite = ninetyPercentBreadSprite;
        else if (health <= 80 && health >= 71)
            spriteRenderer.sprite = eightyPercentBreadSprite;
        else if (health <= 70 && health >= 61)
            spriteRenderer.sprite = seventyPercentBreadSprite;
        else if (health <= 60 && health >= 51)
            spriteRenderer.sprite = sixtyPercentBreadSprite;
        else if (health <= 50 && health >= 41)
            spriteRenderer.sprite = fiftyPercentBreadSprite;
        else if (health <= 40 && health >= 31)
            spriteRenderer.sprite = fortyPercentBreadSprite;
        else if (health <= 30 && health >= 21)
            spriteRenderer.sprite = thirtyPercentBreadSprite;
        else if (health <= 20 && health >= 11)
            spriteRenderer.sprite = twentyPercentBreadSprite;
        else if (health <= 10 && health >= 1)
            spriteRenderer.sprite = tenPercentBreadSprite;
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
