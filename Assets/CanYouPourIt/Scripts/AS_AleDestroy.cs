using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AS_AleDestroy : MonoBehaviour
{

    void Update()
    {
        //destroys itself if it reaches the bottom of the screen
        if (this.transform.position.y < -5.3)
        {
            Destroy(this.gameObject);
        }
    }
    //destroys itself it hits the glass
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Glass")
        {
            Destroy(this.gameObject);
        }
    }
}
