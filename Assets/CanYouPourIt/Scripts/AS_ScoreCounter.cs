using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_ScoreCounter : MonoBehaviour
{
    public int fullGlasses = 0;
    public GameObject WinScreen;

    void Update()
    {
        if (fullGlasses == 4)
        {
            //Debug.Log("WIN!");
            WinScreen.SetActive(true);
        }
    }
}
