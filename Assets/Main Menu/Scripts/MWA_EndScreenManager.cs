using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_EndScreenManager : MonoBehaviour
{
    public GameObject endScreenPanel; // Reference to the end screen panel
    private bool endScreenDisplayed = false; // Flag to track if the end screen is already displayed

    void Start()
    {
        if (endScreenPanel == null)
        {
            endScreenPanel = GameObject.Find("EndScreen"); // Find the EndScreenPanel if not assigned
        }
    }

    void Update()
    {
        if (!endScreenDisplayed) // Only check if the end screen has not been shown yet
        {
            CheckAllLevelsPlayed();
        }
    }

    private void CheckAllLevelsPlayed()
    {
        if (GameManager.Instance.levelStatus.Count >= 8) // Assuming you have 8 minigames
        {
            bool allGamesPlayed = true;
            foreach (var status in GameManager.Instance.levelStatus.Values)
            {
                if (status.StartsWith("not played"))
                {
                    allGamesPlayed = false;
                    break; // Exit early if any game is not played
                }
            }

            if (allGamesPlayed)
            {
                // If all levels are played, enable the end screen panel
                if (endScreenPanel != null && !endScreenPanel.activeSelf)
                {
                    endScreenPanel.SetActive(true);
                    endScreenDisplayed = true; // Mark the end screen as displayed, stop checking
                }
            }
        }
    }

    // Call this method to enable lost levels
    public void EnableLostLevels()
    {
        foreach (var level in GameManager.Instance.levelStatus)
        {
            if (level.Value == "played_lost")
            {
                // Enable the buttons for lost levels (replace with your own logic)
                Debug.Log("Re-enabling level: " + level.Key);
            }
            else
            {
                Debug.Log("Keeping level disabled: " + level.Key);
            }
        }
        endScreenPanel.SetActive(false);
    }
}
