using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class HE_RepairClick : MonoBehaviour
{
    public SpriteRenderer sR;
    public Sprite patched;
    public bool isFixed;
    public HE_WinConScript wN;
    public static int endState = 0;
    public TextMeshProUGUI tutText;
    public AudioSource hammer;

    // Start is called before the first frame update
    void Start()
    {
        isFixed = false;
        tutText.text = "Click to fix";
    }

    // Update is called once per frame
    void Update()
    {
        if (endState == 6)
        {
            isFixed = true;
        }

    }

    public void OnMouseDown()
    {
        endState++;
        sR.sprite = patched;
        hammer.Play();
        Debug.Log(endState);




    }

}
