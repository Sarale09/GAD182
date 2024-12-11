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
    public TextMeshProUGUI gameWinText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public Button backToMenuBtn;

    private float timeRemaining = 30f;
    private bool gameEnded = false;

    public AudioClip gameLostSound;
    public AudioClip gameWinSound;
    public AudioSource inGameAudioSource;
    [SerializeField] private AudioSource backgroundMusic;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
        backgroundMusic.Play();
    }

    private void Update()
    {
        if (!gameEnded)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            FindObjectOfType<TimerAudio>().PlayTickTock(timeRemaining);
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
        else
        {
            gameEnded = true;
            if (health > 0)
            {
                PassedScenario();
            }
            else
            {
                FailedScenario();
            }
        }
    }


    public void ReduceHealth(int amount)
    {
        if (gameEnded) return;

        health -= amount;
        UpdateSprite();

        if (health <= 0)
        {
            health = 0;
            gameEnded = true;
            FailedScenario();
        }
    }

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

    private void FailedScenario()
    {
        backgroundMusic.Stop();

        PlayClip(gameLostSound);

        gameOverText.gameObject.SetActive(true);

        timerText.text = "";

        GameManager.Instance.SetLevelStatus("HoldEmOff", false);  // Marks the game as played and lost

        backToMenuBtn.gameObject.SetActive(true);

        backToMenuBtn.interactable = true; 

        DestroyGameObjects();
    }

    private void PassedScenario()
    {
        backgroundMusic.Stop();

        PlayClip(gameWinSound);

        gameWinText.gameObject.SetActive(true);

        timerText.text = "";

        GameManager.Instance.SetLevelStatus("HoldEmOff", true);  // Marks the game as played and won

        backToMenuBtn.gameObject.SetActive(true);

        backToMenuBtn.interactable = true;

        DestroyGameObjects();
    }


    private void PlayClip(AudioClip clip)
    {
        inGameAudioSource.clip = clip;
        inGameAudioSource.Play();
    }

    private void DestroyGameObjects()
    {
        // Handle the bread differently based on its health
        if (health > 0)
        {
            ServeBread(); // Animate the bread out of the screen
        }
        else
        {
            Destroy(gameObject); // Destroy the bread if no health is left
        }

        // Destroy other objects
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

    // New method to animate bread moving out of the screen
    private void ServeBread()
    {
        // Disable any interaction with the bread
        GetComponent<Collider2D>().enabled = false;

        // Create an upward movement animation
        StartCoroutine(AnimateBreadOut());
    }

    private IEnumerator AnimateBreadOut()
    {
        float duration = 1.0f; // Animation duration
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + new Vector3(0, 8, 0); // Move 10 units upward

        // Play "whoosh" sound if you have one
        //PlayClip(bellDingSound); // Optional, adjust as necessary

        // Smoothly move the bread upwards over time
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Finalize the position
        transform.position = endPosition;

        // Optionally destroy the bread after serving
        Destroy(gameObject);
    }

}
