using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_Movement : MonoBehaviour
{
    public bool direction;
    public float speed;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (direction)
        {
            direction = false;
        }

        if (!direction)
        {
            direction = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();   
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
