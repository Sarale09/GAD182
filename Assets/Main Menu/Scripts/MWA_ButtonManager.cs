using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        UpdateButtonStates(); // Update the button states based on GameManager data
    }

    public void UpdateButtonStates()
    {
        // Check if GameManager instance is available
        if (GameManager.Instance != null)
        {
            // Loop through all the levels in the GameManager's levelStatus dictionary
            foreach (var levelEntry in GameManager.Instance.levelStatus)
            {
                string levelName = levelEntry.Key; // The level name (key)
                string status = levelEntry.Value; // The status (value)

                // Find the button by its name
                Button button = GameObject.Find(levelName)?.GetComponent<Button>();

                if (button != null)
                {
                    Image buttonImage = button.GetComponent<Image>();
                    // Disable button if the level has been played, regardless of whether won or lost
                    if (status == "played_won")
                    {
                        button.interactable = false;
                        buttonImage.color = new Color(0.5f, 1f, 0.5f); // Light green
                    }
                    else if (status == "played_lost")
                    {
                        button.interactable = false;
                        buttonImage.color = new Color(1f, 0.5f, 0.5f); // Light red
                    }
                    else
                    {
                        button.interactable = false;
                        buttonImage.color = Color.white; // Default button color
                    }
                }
            }
        }
    }
}
