using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AS_Instructions : MonoBehaviour
{
    public GameObject titleObj;
    public TextMeshProUGUI instructions;
    // Start is called before the first frame update
    void Start()
    {
        titleObj = GameObject.Find("Title");
        instructions = GameObject.Find("InstructionText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonHover()
    {
        titleObj.SetActive(false);
        switch (gameObject.name)
        {
            case "CanYouPourIt":
                instructions.text = "Press Space to pour the drinks. Make sure not to spill so you don't run out of mead!";
                break;
            case "HeatItUp":
                instructions.text = "Press Space to pump air into the fire and make it grow. The soup will not boil itself!";
                break;
            case "KegRepair":
                instructions.text = "keg repair";
                break;
            case "BarfightScene":
                instructions.text = "bar fight";
                break;
            case "TakeAFlier":
                instructions.text = "take a flier";
                break;
            case "BlacklistCheck":
                instructions.text = "blacklist";
                break;
            case "HoldEmOff":
                instructions.text = "Protect the bread by swatting insects with the Left Mouse Button. Protect it until time runs out to win.";
                break;
            case "TavernTally":
                instructions.text = "Click using Left Mouse Button on notes and coins to give exact change for the displayed amount within 5 seconds";
                break;
        }
        
    }
    public void buttonHoverExit()
    {
        titleObj.SetActive(true);
        instructions.text = "";
    }
}
