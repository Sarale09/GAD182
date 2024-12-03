using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class NW_BaseVillager : NW_Movement2
{
    // public NW_DeathZone deathZone;
    public NW_Counter counter;
    public NW_LeftSpawner spawner;
    
    public delegate void SimpleEvent();
    public event SimpleEvent OnFlierHandout;
    
    private SpriteRenderer spriteRenderer;
    public bool hasFlier;
    
    
    
    // Start is called before the first frame update
    void OnEnable()
    {
        speed = Random.Range(1, 10);
        
        counter = FindObjectOfType<NW_Counter>();
        spawner = FindObjectOfType<NW_LeftSpawner>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //deathZone.OnOutOfBounds += Destroy;
        OnFlierHandout += GiveFlier;

        spawner.peopleCount += 1;
    }

    void OnDisable()
    {
        //deathZone.OnOutOfBounds += Destroy;
        //OnFlierHandout?.Invoke();
        OnFlierHandout -= GiveFlier;

        spawner.peopleCount -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    public void OnMouseDown()
    {
        if (spawner.timerEnd == false)
        {
            if (!hasFlier && counter.fliers > 0)
            {
                Debug.Log("You threw a flier at a villager.");

                spriteRenderer.material.color = Color.blue;
            
                OnFlierHandout?.Invoke(); // (can't call functions in NW_Counter)
            
                hasFlier = true;
            }
        }
    }

    private void GiveFlier()
    {
        counter.ScoreCountdown();
        Debug.Log("You handed out a flier.");
    }
    
}

