using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_Counter : MonoBehaviour
{
    public NW_BaseVillager villager1;
    
    public float fliers;
    
    private void OnEnable()
    {
        //villager1.OnFlierHandout += ScoreCountdown;
        fliers = 15;
        Debug.Log($"You have {fliers} fliers to hand out today.");
    }

    private void OnDisable()
    {
        //villager1.OnFlierHandout -= ScoreCountdown;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ScoreCountdown();
        }
    }

    public void ScoreCountdown()
    {
        fliers -= 1;
        Debug.Log($"You have {fliers} fliers remaining. {name}");
    }
}
