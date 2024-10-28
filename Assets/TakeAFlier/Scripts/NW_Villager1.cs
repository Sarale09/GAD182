using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_Villager1 : NW_BaseVillager
{
    public NW_Counter counter;
    
    /// <summary>
    /// This villager goes from left to right. 
    /// </summary>
    
    
    void OnEnable()
    {
        counter.OnFlierHandout?.AddListener(GiveFlier);
    }

    void OnDisable()
    {
        counter.OnFlierHandout?.Invoke();
        counter.OnFlierHandout?.RemoveListener(GiveFlier);
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
        OnMouseOver();
    }
    
    public void GiveFlier()
    {
        Debug.Log("You threw a flier at a villager.");
    }
}
