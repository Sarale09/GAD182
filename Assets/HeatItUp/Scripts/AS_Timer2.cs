using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AS_Timer2 : MonoBehaviour
{
    public float timeR = 10f;
    public float timeEnd = 0f;
    public TextMeshProUGUI timerUI;
    public bool timerEnd;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerUI.text = "" + (int)timeR;

        if (timeR > 0)
        {
            timeR -= Time.deltaTime;

        }

        if (timeR <= 0 )
        {
            timerEnd = true;
        }
        else
        {
            timerEnd = false;
        }


    }
}
