using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, string> levelStatus = new Dictionary<string, string>(); // Tracks level states
    public GameObject endScreenPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps GameManager persistent across scene loads
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevelStatus(string levelName, bool hasWon)
    {
        if (levelName == "MainMenu") return; // MainMenu itself is not tracked

        // Mark the level as "played" and whether it was "won" or "lost"
        string status = "played_" + (hasWon ? "won" : "lost");

        if (levelStatus.ContainsKey(levelName))
        {
            levelStatus[levelName] = status; // Update status if already exists
        }
        else
        {
            levelStatus.Add(levelName, status); // Add new entry if it doesn't exist
        }

        CheckAllLevelsPlayed(); // Check if all levels are done after updating
    }

    public string GetLevelStatus(string levelName)
    {
        if (levelStatus.ContainsKey(levelName))
        {
            return levelStatus[levelName]; // Return current status of the level
        }
        else
        {
            return "not played"; // If level hasn't been played yet
        }
    }

    private void CheckAllLevelsPlayed()
    {
        if (levelStatus.Count >= 8) // Assuming you have 8 minigames
        {
            foreach (var status in levelStatus.Values)
            {
                if (status.StartsWith("not played"))
                {
                    return; // Exit if any game is still unplayed
                }
            }

            // If all levels are played, enable the end screen panel
            if (endScreenPanel != null)
            {
                endScreenPanel.SetActive(true);
            }
        }
    }

    public void EnableLostLevels()
    {
        foreach (var level in levelStatus)
        {
            if (level.Value == "played_lost")
            {
                // Here you would re-enable the buttons for lost levels
                // Replace with your button re-enabling logic
                Debug.Log("Re-enabling level: " + level.Key);
            }
            else
            {
                Debug.Log("Keeping level disabled: " + level.Key);
            }
        }
        CloseEndScreenPanel();
    }

    public void CloseEndScreenPanel()
    {
        if (endScreenPanel != null)
        {
            endScreenPanel.SetActive(false);
        }
    }

}
