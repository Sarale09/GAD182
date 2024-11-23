using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_SwatterScript : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    
    private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioSource swatAudioSource;

    [SerializeField] private Sprite swatSprite; // Sprite for swatting action
    
    private Sprite originalSprite; // Store the original sprite

    void Start()
    {
        Cursor.visible = false;
        // Get the BoxCollider2D component attached to this GameObject
        boxCollider = GetComponent<BoxCollider2D>();

        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the original sprite at the start
        originalSprite = spriteRenderer.sprite;
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
            // Change to the swatting sprite
            spriteRenderer.sprite = swatSprite;
            swatAudioSource.Play();
            // Get the center and size of the swatter's BoxCollider2D in world coordinates
            Vector2 boxCenter = (Vector2)transform.position + boxCollider.offset;
            Vector2 boxSize = boxCollider.size;

            // Check for insects within the box collider's area
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Insect"))
                {
                    MWA_InsectScript insect = hitCollider.GetComponent<MWA_InsectScript>();
                    if (insect != null)
                    {
                        insect.Die(); // Call the Die method on the insect
                    }
                }
            }
        }

        // Revert to the original sprite when the LMB is released
        if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}
