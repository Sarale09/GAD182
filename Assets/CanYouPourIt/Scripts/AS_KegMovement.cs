using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_KegMovement : MonoBehaviour
{
    bool gameOn = true;
    protected Vector3 movementDir = new Vector3(10, 0, 0);
    public float smoothness = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ensures the keg only moves while the game is running
        if (gameOn)
        {
           //determines direction of keg movement onces it reaches the edge
           if (transform.position.x < -7)
            {
                movementDir = new Vector3(10, 0, 0);
            } 
            else if (transform.position.x > 7)
            {
                movementDir = new Vector3(-10, 0, 0);
            }
            //makes the keg move to whichever direction is on at the time
            transform.position = Vector3.Lerp(transform.position, transform.position + movementDir, Time.deltaTime * smoothness);
        }
    }
}
