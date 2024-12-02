using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HE_GameEnd : MonoBehaviour
{
    public TextMeshProUGUI winEnd;
    public HE_CustomerMovement cM;
    public HE_CustomerTwoMove cTM;
    public bool fightState;
    public HE_TimerScriptTwo timerS;
    public TextMeshProUGUI tutText;
    public AudioSource failNoise;
    


    // Start is called before the first frame update
    void Start()
    {
        fightState = false;
        tutText.text = "Pull Apart";
    }

    // Update is called once per frame
    void Update()
    {
        if (fightState == false && timerS.timerEnd == true)
        {
            winEnd.text = "You have stopped the fight";
            cM.speed = 0f;
            cTM.speed = 0f;

        }



    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            winEnd.text = "All Out Brawl";
            fightState = true;
            cM.speed = 0f;
            cTM.speed = 0f;
            failNoise.Play();
            timerS.timerUI.text = "";
        }
    }


}
