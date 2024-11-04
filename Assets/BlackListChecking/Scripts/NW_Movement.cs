using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_Movement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime);
    }
}
