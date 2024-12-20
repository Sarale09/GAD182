using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AS_GameManager2 : MonoBehaviour
{
    public Animator cauldronAnimator;
    public GameObject pump;
    public GameObject winCanvas;
    public GameObject cauldron;
    private AudioSource boilingSound;
    public TextMeshProUGUI winText;
    public AS_Timer2 timerScript;
    private int counter;

    private void Start()
    {
        cauldronAnimator = cauldron.GetComponent<Animator>();
        boilingSound = cauldron.GetComponent<AudioSource>();
    }
    void Update()
    {
        counter = pump.GetComponent<PumpController>().count;
        if (counter == 10 && timerScript.timerEnd == false)
        {
            //if player wins before time runs out
            winText.text ="Good soup!";
            winCanvas.SetActive(true);
            GameManager.Instance.SetLevelStatus("HeatItUp", true);
        }else if (counter < 10 && timerScript.timerEnd) {
            //if time runs out
            winText.text = "Need cooking lessons?";
            winCanvas.SetActive(true);
            GameManager.Instance.SetLevelStatus("HeatItUp", false);
        }

        if (counter == 5)
        {
            boilingSound.Play();
            cauldronAnimator.Play("CauldronAnim");
        }
    }
}
