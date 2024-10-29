using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_BaseVillager : NW_Movement
{
    // public NW_DeathZone deathZone;
    
    public delegate void SimpleEvent();
    public event SimpleEvent OnFlierHandout;
    
    private SpriteRenderer spriteRenderer;
    private bool hasFlier;
    
    
    
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
        OnFlierHandout?.Invoke();
        OnFlierHandout -= GiveFlier;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
        OnMouseOver();
    }

    

    void Destroy()
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
            //Destroy(gameObject);

            spriteRenderer.material.color = Color.blue;
            
            OnFlierHandout?.Invoke();
            hasFlier = true;
        }
    }
    
    public void GiveFlier()
    {
        Debug.Log("You handed out a flier.");
    }
    
}

