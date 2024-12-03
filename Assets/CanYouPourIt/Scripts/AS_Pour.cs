using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AS_Pour : MonoBehaviour
{
    public GameObject aleDrop;
    public GameObject keg;
    private Vector2 dropLoc;
    private Coroutine aleDropCoroutine;
    public AS_TimerScript timerScript;
    public TMP_Text dropCountText;
    public int dropCount = 40;
    private AudioSource pourSound;

    private void Start()
    {
        pourSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        dropCountText.text = dropCount.ToString();
        //gets the location of the keg in real time
        dropLoc = new Vector2(keg.transform.position.x , 2.95f) ;
        //will start a coroutine that controls the timing of the ale drops while space bar is down.
        if (Input.GetKey(KeyCode.Space) && aleDropCoroutine == null && timerScript.timerEnd == false && dropCount > 0)
        {
            pourSound.Play();
            aleDropCoroutine = StartCoroutine(aleDropTiming());
            dropCount --;
        }
    }

    IEnumerator aleDropTiming()
    {
        //Coroutine that spawns the ale drops every 0.1 seconds to avoid excess instantiations while space bar is down

        //Debug.Log("New Coroutine Started");   Both logs were created to check multiple coroutines were not being created at the same time
        Instantiate(aleDrop, dropLoc, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        //Debug.Log("Coroutine Ended");
        aleDropCoroutine = null;
    }
}
