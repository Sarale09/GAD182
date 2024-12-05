using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Sprite Tick;  // Sprite for win
    [SerializeField] private Sprite Cross; // Sprite for loss

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
                    // Disable the button interaction
                    button.interactable = false;

                    // Find the WinOrLose? GameObject within the button
                    Transform winOrLoseTransform = button.transform.Find("WinLostStatus");
                    if (winOrLoseTransform != null)
                    {
                        GameObject winOrLose = winOrLoseTransform.gameObject;

                        // Enable the WinOrLose? GameObject
                        winOrLose.SetActive(true);

                        // Get the Image component and set the sprite based on the status
                        Image winOrLoseImage = winOrLose.GetComponent<Image>();
                        if (status == "played_won")
                        {
                            winOrLoseImage.sprite = Tick; // Assign tick sprite
                        }
                        else if (status == "played_lost")
                        {
                            winOrLoseImage.sprite = Cross; // Assign cross sprite
                        }
                    }
                }
            }
        }
    }
}
