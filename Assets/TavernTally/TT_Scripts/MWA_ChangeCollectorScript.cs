using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ChangeCollector : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    [SerializeField] public RandomChangeGenerator changeGenerated;

    private float collectedChange;
    [SerializeField] private AudioClip happyCustomerAudio;
    [SerializeField] private AudioClip angryCustomerAudio;
    [SerializeField] private AudioClip angryBossAudio;
    [SerializeField] private AudioClip tickSound1;
    [SerializeField] private AudioClip tickSound2;
    [SerializeField] public AudioSource VoicelineAudioSource;

    public float timeRemaining = 5f;
    private bool timerEnded;
    private bool playFirstTickSound = true;
    private float lastTickTime = -1f;

    [SerializeField] private GameObject TT_villager;
    [SerializeField] private Sprite happyVillagerSprite;
    [SerializeField] private Sprite angryVillagerSprite;
    [SerializeField] private Sprite maliciousVillagerSprite;
    [SerializeField] private SpriteRenderer TT_villagerSpriteRenderer;
    [SerializeField] private GameObject owner;

    public GameObject EndScreen;
    [SerializeField] private TextMeshProUGUI resultsText;
    [SerializeField] private TextMeshProUGUI displayWinMsg;
    [SerializeField] private TextMeshProUGUI displayLoseMsg;

    private float timeElapsed;

    void Start()
    {
        ResetCollectedChange();
        timerEnded = false;
        EndScreen.SetActive(false);
    }

    void Update()
    {
        if (!timerEnded)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimer();
            PlayTickSound();
        }
    }

    public void AddChange(float amount)
    {
        if (timerEnded) return;

        collectedChange += amount;
        collectedChange = Mathf.Round(collectedChange * 100f) / 100f;
        CheckCollectedChange();
    }

    private void CheckCollectedChange()
    {
        float requiredChange = Mathf.Round(changeGenerated.requiredChange * 100f) / 100f;

        if (collectedChange == requiredChange)
        {
            TT_villagerSpriteRenderer.sprite = happyVillagerSprite;
            VoicelineAudioSource.clip = happyCustomerAudio;
            VoicelineAudioSource.Play();

            timerEnded = true;
            GameManager.Instance.gamesWon++;
            StartCoroutine(MoveVillagerOutOfScene(TT_villager, 4f, true));
        }
        else if (collectedChange > requiredChange)
        {
            owner.SetActive(true);
            TT_villagerSpriteRenderer.sprite = maliciousVillagerSprite;
            VoicelineAudioSource.clip = angryBossAudio;
            VoicelineAudioSource.Play();

            timerEnded = true;
            GameManager.Instance.gamesLost++;
            StartCoroutine(MoveVillagerOutOfScene(TT_villager, 6f, false));
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
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.FloorToInt(timeRemaining).ToString();
        }
        else if (!timerEnded)
        {
            timerEnded = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        timerText.text = ""; 

        VoicelineAudioSource.clip = angryCustomerAudio;
        VoicelineAudioSource.Play();

        TT_villagerSpriteRenderer.sprite = angryVillagerSprite;

        GameManager.Instance.gamesLost++;

        // Trigger camera shake
        Camera.main.GetComponent<CameraShake>()?.StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.13f, 0.2f));

        // Show the end screen after the audio ends
        StartCoroutine(ShowEndScreenAfterAudio());
    }


    private void PlayTickSound()
    {
        float currentTime = Mathf.Floor(timeRemaining);

        if (currentTime != lastTickTime)
        {
            VoicelineAudioSource.clip = playFirstTickSound ? tickSound1 : tickSound2;
            VoicelineAudioSource.Play();

            playFirstTickSound = !playFirstTickSound;
            lastTickTime = currentTime;
        }
    }

    private IEnumerator ShowEndScreenAfterAudio()
    {
        // Wait for the angry customer audio to finish playing
        yield return new WaitForSeconds(VoicelineAudioSource.clip.length);

        // Destroy the customer and cash register GameObjects
        if (TT_villager != null)
            Destroy(TT_villager);

        // Call ShowEndScreen with failure condition
        ShowEndScreen(false);
    }


    private IEnumerator MoveVillagerOutOfScene(GameObject villager, float speed, bool isSuccess)
    {
        while (villager.transform.position.x < 12)
        {
            villager.transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return null;
        }
        Destroy(TT_villager);
        ShowEndScreen(isSuccess);
    }

    private void ShowEndScreen(bool isSuccess)
    {
        EndScreen.SetActive(true); // Enable the end screen

        float requiredChange = Mathf.Round(changeGenerated.requiredChange * 100f) / 100f;
        float overChange = collectedChange > requiredChange ? collectedChange - requiredChange : 0f;
        float timeLeft = Mathf.Max(timeRemaining, 0f);
        float timeElapsed = 5f - timeLeft; // Assuming total time is 5 seconds
        
        // Show the appropriate message for win/loss
        displayWinMsg.gameObject.SetActive(isSuccess);
        displayLoseMsg.gameObject.SetActive(!isSuccess);

        // Generate results message
        string resultMessage = $"Required Change: ${requiredChange:F2}\n" +
                               $"Given Change: ${collectedChange:F2}\n" +
                               $"Time Left: {timeLeft:F2}s\n" +
                               $"Time Elapsed: {timeElapsed:F2}s\n" +
                               $"Pay Deduction: ${overChange:F2}\n";

        resultsText.text = resultMessage; // Display results
    }
}
