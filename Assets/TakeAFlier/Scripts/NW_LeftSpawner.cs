using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_LeftSpawner : MonoBehaviour
{
    public GameObject villager1;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(villager1, new Vector2(-10.5f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(villager1, new Vector2(-10.5f, 0), Quaternion.identity);
        }
    }
}
