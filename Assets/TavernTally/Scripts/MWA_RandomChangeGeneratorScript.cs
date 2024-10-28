using UnityEngine;
using UnityEngine.UI;

public class ChangeCalculator : MonoBehaviour
{
    public Text textBox; // Displays the required change
    public float requiredChange;

    void Start()
    {
        requiredChange = Random.Range(20, 2001) * 0.05f; // Pick a random change amount between 1.00 and 100.00 in multiples of 5 cents
        textBox.text = $"Change Needed: ${requiredChange:F2}"; // Display change with two decimal places
    }
}
