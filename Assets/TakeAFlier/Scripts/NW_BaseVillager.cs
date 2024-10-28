using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NW_BaseVillager : NW_Movement
{
    public UnityEvent OutOfBounds;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        OutOfBounds.AddListener(Destroy);
    }

    void OnDisable()
    {
        OutOfBounds.RemoveListener(Destroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        OutOfBounds.Invoke();
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("You handed out a flier.");
            Destroy(gameObject);
        }
    }
    
}

