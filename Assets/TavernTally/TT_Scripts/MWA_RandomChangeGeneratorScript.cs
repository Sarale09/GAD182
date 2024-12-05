using UnityEngine.UI;
using UnityEngine;

public class RandomChangeGenerator : MonoBehaviour
{
    [SerializeField] private Text[] textBoxes; // Serialized array of Text components (the pre-existing message boxes)
    public float requiredChange;

    void Start()
    {
        // Pick a random change amount between 1.00 and 100.00 in multiples of 5 cents
        requiredChange = Random.Range(20, 2001) * 0.05f;

        // Create the string with two decimal places
        string changeText = $"{requiredChange:F2}";

        // Ensure that there are enough text boxes in the array
        if (textBoxes.Length < changeText.Length)
        {
            Debug.LogWarning("Not enough text boxes for the string length!");
            return;
        }

        // Start filling from the rightmost text box, ensuring the decimal point is placed correctly
        int textBoxIndex = textBoxes.Length - 1;

        // Loop through the string and fill each text box with a character, starting from the right
        for (int i = changeText.Length - 1; i >= 0; i--)
        {
            textBoxes[textBoxIndex].text = changeText[i].ToString();
            textBoxIndex--;
        }

        // Fill any remaining text boxes to the left with an empty string (optional, to clear them)
        while (textBoxIndex >= 0)
        {
            textBoxes[textBoxIndex].text = "";
            textBoxIndex--;
        }
    }
}
