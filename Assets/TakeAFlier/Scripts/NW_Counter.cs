using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_Counter : MonoBehaviour
{
    public NW_BaseVillager villager1;
    
    
    public float fliers = 15;
    
    private void OnEnable()
    {
        villager1.OnFlierHandout += ScoreCountdown;
        Debug.Log($"You have {fliers} fliers to hand out today.");
    }

    private void OnDisable()
    {
        villager1.OnFlierHandout -= ScoreCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ScoreCountdown()
    {
        fliers -= 1;
        Debug.Log($"You have {fliers} fliers remaining.");
    }
}
