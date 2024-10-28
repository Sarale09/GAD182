using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_Counter : MonoBehaviour
{
    public float fliers = 15;
    public UnityEvent OnFlierHandout;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        OnFlierHandout.AddListener(ScoreCountdown);
        Debug.Log($"You have {fliers} fliers to hand out today.");
    }

    private void OnDisable()
    {
        OnFlierHandout.RemoveListener(ScoreCountdown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreCountdown()
    {
        fliers -= 1;
        Debug.Log($"You have {fliers} fliers remaining.");
    }
}
