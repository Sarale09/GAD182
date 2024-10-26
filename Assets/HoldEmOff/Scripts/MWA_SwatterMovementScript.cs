using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_SwatterMovementScript : MonoBehaviour
{
    // List to track insects in the swatter's collider area
    private List<Collider2D> insectsInRange = new List<Collider2D>();

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

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Check again to make sure the list is not empty before accessing
            if (insectsInRange.Count > 0)
            {
                // Squash the first insect in the list
                Destroy(insectsInRange[0].gameObject);
                insectsInRange.RemoveAt(0); // Remove it from the list after squashing
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
