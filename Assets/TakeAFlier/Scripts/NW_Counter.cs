using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NW_Counter : MonoBehaviour
{
    public NW_BaseVillager villager1;
    public TextMeshProUGUI instructionsText;
    
    public float fliers = 5;
    
    private void OnEnable()
    {
        //villager1.OnFlierHandout += ScoreCountdown;
        Debug.Log($"You have {fliers} fliers to hand out today.");

        instructionsText.text = "Click on the villagers passing by to give them a flier!";
    }

    private void OnDisable()
    {
        //villager1.OnFlierHandout -= ScoreCountdown;
    }

    private void Update()
    {
        // function testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            ScoreCountdown();
        }

        
    }

    public void ScoreCountdown()
    {
        if (fliers > 0)
        {
            fliers -= 1;
            Debug.Log($"You have {fliers} fliers remaining.");
        }
        
        if (fliers <= 0)
        {
            Debug.Log("You have handed out all the fliers!");
        }
    }
}
