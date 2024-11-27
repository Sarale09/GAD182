using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class ChangeCollector : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Displays remaining time

    [SerializeField] public RandomChangeGenerator changeGenerated; // Reference to ChangeGenerator script

    private float collectedChange; // Tracks the total collected change

    [SerializeField] private AudioClip happyCustomerAudio;
    [SerializeField] private AudioClip angryCustomerAudio;
    [SerializeField] private AudioClip angryBossAudio;

    [SerializeField] private AudioClip tickSound1; // First tick sound
    [SerializeField] private AudioClip tickSound2; // Second tick sound
    [SerializeField] public AudioSource VoicelineAudioSource;

    public float timeRemaining = 5f; // Set initial timer duration

    private bool timerEnded;
    private bool playFirstTickSound = true; // Boolean to alternate between tick sounds
    private float lastTickTime = -1f; // Tracks the last second when a tick sound was played

    [SerializeField] private GameObject TT_villager; 
    [SerializeField] private Sprite happyVillagerSprite;
    [SerializeField] private Sprite angryVillagerSprite;
    [SerializeField] private Sprite maliciousVillagerSprite;
    [SerializeField] private Sprite neutralVillagerSprite;
    [SerializeField] private SpriteRenderer TT_villagerSpriteRenderer; // Reference to the SpriteRenderer

    [SerializeField] private GameObject owner;

    void Start()
    {
        ResetCollectedChange();
        timerEnded = false;
    }

    void Update()
    {
        if (!timerEnded)
        {
            UpdateTimer();
            PlayTickSound(); // Play the tick sound every second based on the timer
        }
    }

    public void AddChange(float amount)
    {
        if (timerEnded) return; // Prevent adding change if timer has ended

        // Add the change, and round to 2 decimal places
        collectedChange += amount;
        collectedChange = Mathf.Round(collectedChange * 100f) / 100f;  // Round to 2 decimal places
        CheckCollectedChange();
    }

    private void CheckCollectedChange()
    {
        float requiredChange = Mathf.Round(changeGenerated.requiredChange * 100f) / 100f;  // Round to 2 decimal places

        if (collectedChange == requiredChange)
        {
            TT_villagerSpriteRenderer.sprite = happyVillagerSprite; // Switch to happy sprite

            // Play happy customer sound
            VoicelineAudioSource.clip = happyCustomerAudio;
            VoicelineAudioSource.Play();

            timerEnded = true; // Stop timer if player wins

            GameManager.Instance.gamesWon++;

            StartCoroutine(MoveVillagerOutOfScene(TT_villager, 4f));
        }
        else if (collectedChange > requiredChange)
        {
            owner.SetActive(true);

            TT_villagerSpriteRenderer.sprite = maliciousVillagerSprite; // Switch to malicious sprite

            // Play angry boss sound
            VoicelineAudioSource.clip = angryBossAudio;
            VoicelineAudioSource.Play();

            timerEnded = true;

            GameManager.Instance.gamesLost++;

            StartCoroutine(MoveVillagerOutOfScene(TT_villager, 6f));
        }
        else
        {
        }
    }


    private void ResetCollectedChange()
    {
        collectedChange = 0;
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;  // Decrease time by frame time (no rounding here)
            timerText.text = Mathf.FloorToInt(timeRemaining).ToString(); // Display remaining time as a whole number
        }
        else if (!timerEnded) // End game only if not already won
        {
            timerEnded = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        timerText.text = "";

        // Play angry customer sound when time runs out
        VoicelineAudioSource.clip = angryCustomerAudio;
        VoicelineAudioSource.Play();

        // change customer sprite to angry
        TT_villagerSpriteRenderer.sprite = angryVillagerSprite;

        // Trigger camera shake
        Camera.main.GetComponent<CameraShake>()?.StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.13f, 0.2f));

        GameManager.Instance.gamesLost++;

        
    }


    // Function to alternate between tick sounds every second
    private void PlayTickSound()
    {
        // Check if a whole second has passed by comparing the floored time remaining
        float currentTime = Mathf.Floor(timeRemaining);

        // Only play a tick sound if a second has passed since the last sound
        if (currentTime != lastTickTime)
        {
            // Alternate between tick sounds
            if (playFirstTickSound)
            {
                VoicelineAudioSource.clip = tickSound1;
            }
            else
            {
                VoicelineAudioSource.clip = tickSound2;
            }

            VoicelineAudioSource.Play(); // Play the selected tick sound

            // Toggle the boolean to alternate the tick sound on the next second
            playFirstTickSound = !playFirstTickSound;

            // Update the last tick time to prevent playing the same sound multiple times in a second
            lastTickTime = currentTime;
        }
    }

    private IEnumerator MoveVillagerOutOfScene(GameObject villager, float speed)
    {
        while (villager.transform.position.x < 30)
        {
            // Move the villager to the right
            villager.transform.Translate(Vector3.right * speed * Time.deltaTime);

            yield return null; // Wait for the next frame
        }

        // Optionally, disable the villager after they leave the screen
        TT_villager.SetActive(false);
    }

}
