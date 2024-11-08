using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpController : MonoBehaviour
{
    Animator animator;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> fireSprites = new List<Sprite>();
    public int count = 0;
    public string fireNum;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("AirPumpAnim 0");

            if (count < 4)
            {
                spriteRenderer.sprite = fireSprites[count];
                count++;
            }else if (count == 4) {
                Debug.Log("WIN");
            }
        }
    }
}
