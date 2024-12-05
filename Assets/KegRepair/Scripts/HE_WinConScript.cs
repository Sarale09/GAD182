using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HE_WinConScript : MonoBehaviour
{
    public HE_RepairClick rC;
    public HE_TimerScript tS;
    public TextMeshProUGUI winLoss;
    public GameObject backToMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       if(rC.isFixed == true && tS.timerEnd == false)
       {
            winLoss.text = "Keg Repaired";
            GameManager.Instance.SetLevelStatus("KegRepair", true);
            backToMenu.SetActive(true);
       }
       if(tS.timerEnd == true && rC.isFixed != true)
       {
            winLoss.text = "You Failed";
            GameManager.Instance.SetLevelStatus("KegRepair", false);
            backToMenu.SetActive(true);
        }



    }
}
