using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_GameManager : MonoBehaviour
{
    public List<string> villagerNames;
    public List<string> blacklist;
    
    // Start is called before the first frame update
    void Start()
    {
        blacklist.Add("Scott");
        
        villagerNames.Add("Scott");
        villagerNames.Add("Robert");
        villagerNames.Add("Tom");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(villagerNames.Count);
        }
    }
}
