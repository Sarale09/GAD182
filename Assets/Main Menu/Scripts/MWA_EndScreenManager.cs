using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (GameManager.Instance.levelStatus.Count >= 8)
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

    // This method to re-enables lost mini games
    public void EnableLostLevels()
    {
        foreach (var level in GameManager.Instance.levelStatus)
        {
            if (level.Value == "played_lost")
            {
                Button button = GameObject.Find(level.Key)?.GetComponent<Button>();
                if (button != null)
                {
                    // Enable the button interaction
                    button.interactable = true;
                    Transform winOrLoseTransform = button.transform.Find("WinLostStatus");
                    if (winOrLoseTransform != null)
                    {
                        GameObject winOrLose = winOrLoseTransform.gameObject;

                        // Disable the Ticks and Crosses
                        winOrLose.SetActive(false);
                    }
                }
            }
            else
            {
            }
        }
        endScreenPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
