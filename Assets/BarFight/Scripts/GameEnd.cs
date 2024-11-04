using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public TextMeshProUGUI winEnd;
    public CustomerMovement cM;
    public CustomerTwoMove cTM;
    public bool fightState;
    public HE_TimerScript timerS;
    


    // Start is called before the first frame update
    void Start()
    {
        fightState = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fightState == false && timerS.timeR <= 0)
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
        }
    }


}
