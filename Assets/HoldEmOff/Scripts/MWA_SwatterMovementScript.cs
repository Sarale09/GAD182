using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_SwatterMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the z position to 0 since we only want movement on the x and y axes
        worldPosition.z = 0;

        // Update the position of the swatter to follow the mouse
        transform.position = worldPosition;
    }
}
