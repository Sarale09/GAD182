using UnityEngine;
using UnityEngine.UI;

public class ChangeCollector : MonoBehaviour
{
    public Text timerText; // Displays remaining time

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
        Debug.Log("Added change: " + amount + ", Total collected: " + collectedChange);
        CheckCollectedChange();
    }

    void CheckCollectedChange()
    {
        // Round the required change to 2 decimal places for comparison
        float requiredChange = Mathf.Round(changeGenerated.requiredChange * 100f) / 100f;  // Round to 2 decimal places

        if (collectedChange == requiredChange)
        {
            // Play happy customer sound if collected change matches required change
            VoicelineAudioSource.clip = happyCustomerAudio;
            VoicelineAudioSource.Play();
            timerEnded = true; // Stop timer if player wins
        }
        else if (collectedChange > requiredChange)
        {
            // Play angry boss sound if collected change exceeds required change
            VoicelineAudioSource.clip = angryBossAudio;
            VoicelineAudioSource.Play();
            timerEnded = true; // Stop timer if player has overchanged
        }
        else
        {
            // Do nothing if still collecting change
        }
    }

    void ResetCollectedChange()
    {
        collectedChange = 0;
    }

    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;  // Decrease time by frame time (no rounding here)
            timerText.text = timeRemaining.ToString("F2"); // Display remaining time with 2 decimal places
        }
        else if (!timerEnded) // End game only if not already won
        {
            timerEnded = true;
            EndGame();
        }
    }

    void EndGame()
    {
        timerText.text = "";
        // Play angry customer sound when time runs out
        VoicelineAudioSource.clip = angryCustomerAudio;
        VoicelineAudioSource.Play();
    }

    // Function to alternate between tick sounds every second based on the timer
    void PlayTickSound()
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
}
