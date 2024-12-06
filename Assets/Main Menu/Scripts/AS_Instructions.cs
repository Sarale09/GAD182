using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AS_Instructions : MonoBehaviour
{
    public GameObject titleObj;
    public TextMeshProUGUI instructions;

    public Image GameVisual; // Reference to the Image component
    public Sprite CanYouPourIt;
    public Sprite HeatItUp;
    public Sprite KegRepair;
    public Sprite BarFight;
    public Sprite TakeAFlier;
    public Sprite BlackList;
    public Sprite HoldEmOff;
    public Sprite TavernTally;

    // Start is called before the first frame update
    void Start()
    {
        titleObj = GameObject.Find("Title");
        instructions = GameObject.Find("InstructionText")?.GetComponent<TextMeshProUGUI>();
    }

    public void buttonHover()
    {
        if (titleObj != null)
        {
            titleObj.SetActive(false); // Hide the title
        }

        // Set the instructions text based on the button pressed
        switch (gameObject.name)
        {
            case "CanYouPourIt":
                GameVisual.sprite = CanYouPourIt;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Press Space to pour the drinks. Make sure not to spill so you don't run out of mead!";
                break;
            case "HeatItUp":
                GameVisual.sprite = HeatItUp;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Press Space to pump air into the fire and make it grow. The soup will not boil itself!";
                break;
            case "KegRepair":
                GameVisual.sprite = KegRepair;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Click on the holes to repair the keg before time runs out";
                break;
            case "BarfightScene":
                GameVisual.sprite = BarFight;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Click and drag the customers away from each other to prevent a fight";
                break;
            case "TakeAFlier":
                GameVisual.sprite = TakeAFlier;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Hand out fliers to the villagers passing by by clicking on them.";
                break;
            case "BlacklistCheck":
                GameVisual.sprite = BlackList;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Check the list of names on the blacklist carefully, then choose to either let the next villager in with the Y key or to shoo them away with the N key.";
                break;
            case "HoldEmOff":
                GameVisual.sprite = HoldEmOff;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Protect the bread by swatting insects with the Left Mouse Button. Protect it until time runs out to win.";
                break;
            case "TavernTally":
                GameVisual.sprite = TavernTally;
                GameVisual.gameObject.SetActive(true);
                instructions.text = "Click using Left Mouse Button on notes and coins to give exact change for the displayed amount within 5 seconds";
                break;
        }
    }

    public void buttonHoverExit()
    {
        if (titleObj != null)
        {
            titleObj.SetActive(true); // Re-enable the title
        }
        instructions.text = ""; // Clear the instructions
        if (GameVisual != null)
        {
            GameVisual.gameObject.SetActive(false); // Hide the image again
        }
    }
}
