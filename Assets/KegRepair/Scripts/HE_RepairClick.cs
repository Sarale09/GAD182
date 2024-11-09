using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class HE_RepairClick : MonoBehaviour
{
    public Color red;
    public Color blue;
    public bool isFixed;
    public HE_WinConScript wN;
    public static int endState = 0;
    public TextMeshProUGUI tutText;


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
        MeshRenderer mR = GetComponent<MeshRenderer>();
        mR.material.color = blue;
        Debug.Log(endState);




    }

}
