using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AS_ScoreCounter : MonoBehaviour
{
    public AS_TimerScript timerScript;
    public int fullGlasses = 0;
    public TextMeshProUGUI resultText;
    public GameObject resultScreen;

    void Update()
    {
        if(timerScript.timerEnd){
            resultText.text = "Too Slow, bad bartender";
            resultScreen.SetActive(true);
        }
        else if (fullGlasses == 5)
        {
            //Debug.Log("WIN!");
            resultText.text = "Good Pouring Skills!\r\nYou Win!!!";
            resultScreen.SetActive(true);
        }
    }
}
