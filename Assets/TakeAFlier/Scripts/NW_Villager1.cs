using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_Villager1 : NW_BaseVillager
{
    public delegate void SimpleEvent();
    public event SimpleEvent OnFlierHandout;
    
    /// <summary>
    /// This villager goes from left to right. 
    /// </summary>
    
    
    void OnEnable()
    {
        OnFlierHandout += GiveFlier;
    }

    void OnDisable()
    {
        OnFlierHandout?.Invoke();
        OnFlierHandout -= GiveFlier;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
        OnMouseOver();

        // if (Input.GetKeyDown(KeyCode.Y))
        // {
        //     OnFlierHandout?.Invoke();
        // }
    }
    
    public void GiveFlier()
    {
        Debug.Log("You handed out a flier.");
    }
}
