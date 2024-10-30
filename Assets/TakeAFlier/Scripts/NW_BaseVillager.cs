using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_BaseVillager : NW_Movement
{
    // public NW_DeathZone deathZone;
    public NW_Counter counter;
    
    public delegate void SimpleEvent();
    public event SimpleEvent OnFlierHandout;
    
    private SpriteRenderer spriteRenderer;
    public bool hasFlier;
    
    
    
    // Start is called before the first frame update
    void OnEnable()
    {
        //deathZone.OnOutOfBounds += Destroy;
        OnFlierHandout += GiveFlier;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnDisable()
    {
        //deathZone.OnOutOfBounds += Destroy;
        //OnFlierHandout?.Invoke();
        OnFlierHandout -= GiveFlier;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
    }

    private void Destroy()
    {
        // this.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void OnMouseOver()
    {
        // Debug.Log("Mouse is currently hovering over.");
        
        if (Input.GetMouseButtonDown(0) && !hasFlier)
        {
            Debug.Log("You threw a flier at a villager.");

            spriteRenderer.material.color = Color.blue;
            
            OnFlierHandout?.Invoke(); // (can't call functions in NW_Counter)
            
            // Debug.Log("There are currently " + counter.fliers + " fliers!" + name);
            // counter.ScoreCountdown(); (flier count doesn't reset for some reason)
            
            hasFlier = true;
        }
    }

    private void GiveFlier()
    {
        counter.ScoreCountdown();
        Debug.Log("You handed out a flier.");
    }
    
}

