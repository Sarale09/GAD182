using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpController : MonoBehaviour
{
    Animator animator;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> fireSprites = new List<Sprite>();
    public int count = 0;
    public int spriteNum = 0;
    public string fireNum;
    private AudioSource pumpSound;
    // Start is called before the first frame update
    void Start()
    {
        pumpSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Plays animation and sound
            animator.Play("AirPumpAnim 0");
            pumpSound.Play();

            //updates sprites at different intervals when space is pressed
            switch (count)
            {
                case 0:
                    UpdateSprites(); break;
                case 2:
                    UpdateSprites(); break;
                case 5:
                    UpdateSprites(); break;
                case 9:
                    UpdateSprites(); break;
                default:
                    count++;
                    break;
            }

        }
    }

    void UpdateSprites()
    {
        //function that updates sprite, count, and sprite num
        count++;
        spriteRenderer.sprite = fireSprites[spriteNum];
        spriteNum++;
    }
}
