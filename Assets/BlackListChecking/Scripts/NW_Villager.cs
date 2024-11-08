using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_Villager : MonoBehaviour
{
    public NW_GameManager manager;
    
    public string villagerName;
    public bool isBanned;
    
    void OnEnable()
    {
        manager = FindObjectOfType<NW_GameManager>();
        manager.villagerList.Add(gameObject);
        
        villagerName = manager.namePlaceholder;
    }

    private void OnDisable()
    {
        manager.villagerList.Remove(gameObject);
    }

    void Update()
    {
        if (manager.blacklist.Contains(villagerName))
        {
            isBanned = true;
        }
    }
}
