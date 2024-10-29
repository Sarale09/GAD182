using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_DeathZone : MonoBehaviour
{
    public GameObject villager;
    
    //public delegate void SimpleEvent();
    //public event SimpleEvent OnOutOfBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        villager = FindObjectOfType<GameObject>();
        
        if (other.gameObject.CompareTag("Villager")) // compare class/tag
        {
            Destroy(villager);
        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Villager"))
    //     {
    //         Destroy(villager);
    //     }
    // }
}
