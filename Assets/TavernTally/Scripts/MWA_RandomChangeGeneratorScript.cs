using UnityEngine;
using UnityEngine.UI;

public class RandomChangeGenerator : MonoBehaviour
{
    public Text textBox; // Displays the required change
    public float requiredChange;

    void Start()
    {
        // Pick a random change amount between 1.00 and 100.00 in multiples of 5 cents
        requiredChange = Random.Range(20, 2001) * 0.05f;

        // Display change with two decimal places
        textBox.text = $"Change Needed: ${requiredChange:F2}"; 
    }
}
