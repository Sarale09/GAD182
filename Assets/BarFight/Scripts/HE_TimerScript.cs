using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HE_TimerScript : MonoBehaviour
{
    public float timeR = 10f;
    public float timeEnd = 0f;
    public TextMeshProUGUI timerUI;
    



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
    }
}
