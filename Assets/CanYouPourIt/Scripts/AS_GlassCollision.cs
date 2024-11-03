using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_GlassCollision : MonoBehaviour
{
    public int fullness = 0;
    public bool isFull = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (isFull == false && fullness >= 100)
        {
            isFull = true;
            Debug.Log("Full Glass");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ale" && isFull == false)
        {
            Debug.Log("collision");
            fullness += 25;
        }
    }
}
