using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HE_WinConScript : MonoBehaviour
{
    public HE_RepairClick rC;
    public HE_TimerScript tS;
    public TextMeshProUGUI winLoss;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rC.holesPatched.Count >= 6)
        {
            rC.isFixed = true;
        }
        if (rC.isFixed == true && tS.timerEnd == false)
        {
            winLoss.text = "You have fixed the keg";
        }
    }
}
