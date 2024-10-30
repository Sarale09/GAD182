using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AS_Pour : MonoBehaviour
{
    public GameObject aleDrop;
    public GameObject keg;
    private Vector3 dropLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dropLoc = keg.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(aleDrop, dropLoc, Quaternion.identity);
        }
    }
}
