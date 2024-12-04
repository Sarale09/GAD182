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
    public NW_Spawner spawner;
    
    public delegate void SimpleEvent();
    public event SimpleEvent OnFlierHandout;
    
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite flierSprite;
    public bool hasFlier;
    public bool spawnedLeft;
    public bool spawnedRight;
    
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 1;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        speed = Random.Range(1, 10);
        
        counter = FindObjectOfType<NW_Counter>();
        spawner = FindObjectOfType<NW_Spawner>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //deathZone.OnOutOfBounds += Destroy;
        OnFlierHandout += GiveFlier;

        spawner.peopleCount += 1;

        if (transform.position.x > 10)
        {
            spawnedRight = true;
        }
        
        if (transform.position.x < -10)
        {
            spawnedLeft = true;
        }
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
        if (spawnedLeft)
        {
            MoveRight();
        }
        else if (spawnedRight)
        {
            spriteRenderer.flipX = true;
            MoveLeft();
        }
        

        if (transform.position.x > 12 || transform.position.x < -12)
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

                // spriteRenderer.material.color = Color.blue;
                spriteRenderer.sprite = flierSprite;
            
                OnFlierHandout?.Invoke(); // (can't call functions in NW_Counter)
            
                hasFlier = true;

                if (!audioClip)
                {
                    audioSource.clip = audioClip;
                }
                audioSource.PlayOneShot(audioClip);
            }
        }
    }

    private void GiveFlier()
    {
        counter.ScoreCountdown();
        Debug.Log("You handed out a flier.");
    }
    
}

