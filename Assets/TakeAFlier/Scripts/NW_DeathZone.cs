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
    
    private void OnTriggerEnter(Collider other)
    {
        villager = other.gameObject;
        
        if (other.gameObject.CompareTag("Villager")) // compare class/tag
        {
            //OnOutOfBounds?.Invoke();
            Destroy(villager);
        }
        
    }
}
