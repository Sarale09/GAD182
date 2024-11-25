using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_GlassCollision : MonoBehaviour
{
    public int fullness = 0;
    public bool isFull = false;
    public List<Sprite> sprites = new List<Sprite>();

    void Update()
    {
    //sets the glass to full once it reaches 100
      if (isFull == false && fullness >= 4)
        {
            isFull = true;
            FindObjectOfType<AS_ScoreCounter>().fullGlasses += 1;
            Debug.Log("Full Glass");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //adds to fullness if the ale drop hits the glass
        //only allows adding to fullness if the glass is not full yet
        if (collision.gameObject.tag == "Ale" && isFull == false )
        {
            //Debug.Log("collision");
            fullness ++;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[fullness];
        }
    }
}
