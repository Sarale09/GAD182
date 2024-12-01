using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, string> levelStatus = new Dictionary<string, string>(); // Tracks level states

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
}
