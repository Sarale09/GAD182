using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MWA_EndScreenManager : MonoBehaviour
{
    public GameObject endScreenPanel; // Reference to the end screen panel
    private bool endScreenDisplayed = false; // Flag to track if the end screen is already displayed
    public TextMeshProUGUI EndScreenMessage;
    public Button RetryBtn;
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
            bool allGamesWon = true; // Flag to check if all games were won

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
                // Check if all played levels were won
                foreach (var status in GameManager.Instance.levelStatus.Values)
                {
                    if (status != "won") // If any level is not won, set allGamesWon to false
                    {
                        allGamesWon = false;
                        break; // Exit early if any game was lost
                    }
                }

                if (allGamesPlayed)
                {
                    // If all levels are played, enable the end screen panel
                    if (endScreenPanel != null && !endScreenPanel.activeSelf)
                    {
                        endScreenPanel.SetActive(true);
                        endScreenDisplayed = true; // Mark the end screen as displayed, stop checking

                        // Update the message based on whether all games were won
                        if (allGamesWon)
                        {
                            EndScreenMessage.text = "Good Job! You have successfully saved the tavern!";
                            RetryBtn.interactable = false;
                        }
                    }
                }
            }
        }
    }

    // This method to re-enables lost mini games
    public void EnableLostLevels()
    {
        foreach (var level in GameManager.Instance.levelStatus.ToList()) // Use ToList to avoid modifying the dictionary during iteration
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

                // Remove the "played_lost" status to allow replay
                GameManager.Instance.levelStatus.Remove(level.Key);
            }
        }
        endScreenPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
