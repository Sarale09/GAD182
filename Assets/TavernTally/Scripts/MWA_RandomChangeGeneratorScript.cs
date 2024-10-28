using UnityEngine;
using UnityEngine.UI;

public class ChangeCalculator : MonoBehaviour
{
    public Text textBox; // Displays the required change
    public int requiredChange;

    void Start()
    {
        GenerateNewChange();
    }

    void GenerateNewChange()
    {
        requiredChange = Random.Range(1, 21) * 5; // Pick a random change amount in multiples of 5 between 5 and 100
        textBox.text = $"Change Needed: ${requiredChange}"; // Display change as a whole dollar amount
    }
}
