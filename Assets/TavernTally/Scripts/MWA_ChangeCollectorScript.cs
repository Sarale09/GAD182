using UnityEngine;
using UnityEngine.UI;

public class ChangeCollector : MonoBehaviour
{
    public Text messageBox; // Displays success or error messages
    public Text timerText; // Displays remaining time
    [SerializeField]
    public RandomChangeGenerator changeGenerated; // Reference to ChangeGenerator script
    private float collectedChange; // Tracks the total collected change

    public float timeRemaining = 5f; // Set initial timer duration
    private bool timerEnded;

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
        }
    }

    public void AddChange(float amount)
    {
        if (timerEnded) return; // Prevent adding change if timer has ended

        collectedChange += amount;
        Debug.Log("Added change: " + amount + ", Total collected: " + collectedChange);
        CheckCollectedChange();
    }

    void CheckCollectedChange()
    {
        if (collectedChange == changeGenerated.requiredChange)
        {
            messageBox.text = "Customer: Cheers! Mate";
            timerEnded = true; // Stop timer if player wins
        }
        else if (collectedChange > changeGenerated.requiredChange)
        {
            messageBox.text = "Owner: Well that's is coming out of your paycheck !!";
            timerEnded = true; // Stop timer if player has overchanged
        }
        else
        {
            messageBox.text = ""; // No message if still collecting
        }
    }

    void ResetCollectedChange()
    {
        collectedChange = 0;
        messageBox.text = ""; // Clear any messages
    }

    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time remaining: " + timeRemaining.ToString("F2") + " sec"; // Display remaining time with 2 decimal places
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
        messageBox.text = "Customer: What's taking so long !! My 5 year old can do better than ya!";
    }
}
