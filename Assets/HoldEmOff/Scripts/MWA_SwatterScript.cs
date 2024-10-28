using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_SwatterMovementScript : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    void Start()
    {
        // Get the BoxCollider2D component attached to this GameObject
        boxCollider = GetComponent<BoxCollider2D>();
    }
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
            // Use the BoxCollider2D size for the overlap check
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Insect"))
                {
                    Destroy(hitCollider.gameObject); // Kill the insect
                    break; // Exit after killing the first insect found
                }
            }
        }
    }
}
