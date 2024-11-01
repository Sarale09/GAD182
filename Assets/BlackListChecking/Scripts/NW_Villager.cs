using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_Villager : MonoBehaviour
{
    public NW_GameManager manager;
    
    public string villagerName;
    public bool isBanned;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        manager = FindObjectOfType<NW_GameManager>();
        manager.villagerList.Add(gameObject);
        
        //villagerName = "Scott";
        
        villagerName = manager.villagerNameList[manager.randomValue];
    }

    private void OnDisable()
    {
        manager.villagerList.Remove(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (manager.blacklist.Contains(villagerName))
        {
            isBanned = true;
        }
    }
}
