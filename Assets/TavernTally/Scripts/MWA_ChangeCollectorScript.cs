using UnityEngine;
using UnityEngine.UI;

public class ChangeCollector : MonoBehaviour
{
    public Text messageBox; // Displays success or error messages
    [SerializeField]
    public RandomChangeGenerator changeGenerated; // Reference to ChangeGenerator script
    private float collectedChange; // Tracks the total collected change

    void Start()
    {
        ResetCollectedChange();
    }

    public void AddChange(float amount)
    {
        collectedChange += amount; // Add the amount corresponding to the button clicked
        CheckCollectedChange();
    }

    void CheckCollectedChange()
    {
        if (collectedChange == changeGenerated.requiredChange)
        {
            messageBox.text = "Hurray! Good Job!";
        }
        else if (collectedChange > changeGenerated.requiredChange)
        {
            messageBox.text = "Oops! Too much!";
        }
        else
        {
            messageBox.text = ""; // no message if still collecting
        }
    }

    public void ResetCollectedChange()
    {
        collectedChange = 0;
        messageBox.text = ""; // Clear any messages
    }
}
