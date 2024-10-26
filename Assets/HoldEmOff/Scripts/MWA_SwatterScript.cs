using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_SwatterMovementScript : MonoBehaviour
{
    // List to track insects that collided with the swatter
    private List<Collider2D> insectsInRange = new List<Collider2D>();

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

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (insectsInRange.Count > 0)
            {
                Destroy(insectsInRange[0].gameObject);
                insectsInRange.RemoveAt(0);
            }
        }
    }

    // Called when an insect enters the swatter's trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Insect") && !insectsInRange.Contains(other))
        {
            insectsInRange.Add(other);
        }
    }
}
