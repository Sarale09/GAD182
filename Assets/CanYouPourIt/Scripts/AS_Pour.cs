using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AS_Pour : MonoBehaviour
{
    public GameObject aleDrop;
    public GameObject keg;
    private Vector3 dropLoc;
    private Coroutine aleDropCoroutine;

    void Update()
    {
        //gets the location of the keg in real time
        dropLoc = keg.transform.position;
        //will start a coroutine that controls the timing of the ale drops while space bar is down.
        if (Input.GetKey(KeyCode.Space) && aleDropCoroutine == null)
        {
            aleDropCoroutine = StartCoroutine(aleDropTiming());
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
