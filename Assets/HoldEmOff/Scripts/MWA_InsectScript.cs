using System.Collections;
using UnityEngine;

public class MWA_InsectScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Sprite squishedSprite; // The sprite to display when squished

    [SerializeField]
    private GameObject bloodEffectPrefab; // Prefab of the blood effect

    private Rigidbody2D rigidbody;
    private Vector2 targetDirection;
    private Bread breadScript; // Reference to the Bread script
    private SpriteRenderer spriteRenderer; // Reference to the insect's SpriteRenderer
    private bool isEating = false; // Track if insect is currently eating
    private bool isDead = false; // Track if insect is dead

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject breadObject = GameObject.FindWithTag("Bread");
        if (breadObject != null)
        {
            breadScript = breadObject.GetComponent<Bread>();
        }
    }

    private void FixedUpdate()
    {
        if (breadScript == null || isDead) return;

        UpdateToTargetDirection();
        RotateToTarget();
        SetVelocity();
    }

    private void UpdateToTargetDirection()
    {
        targetDirection = (breadScript.transform.position - transform.position).normalized;
    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private void SetVelocity()
    {
        rigidbody.velocity = targetDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bread") && !isDead)
        {
            isEating = true;
            StartCoroutine(EatBread());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bread"))
        {
            isEating = false;
            StopCoroutine(EatBread());
        }
    }

    private IEnumerator EatBread()
    {
        while (isEating && breadScript != null)
        {
            breadScript.ReduceHealth(1);
            yield return new WaitForSeconds(2f); // Wait for 2 seconds between each health reduction
        }
    }
    public void Die()
    {
        if (isDead) return;

        // Stop movement and animations
        isDead = true;
        rigidbody.velocity = Vector2.zero;
        rigidbody.isKinematic = true;

        // Freeze rotation to stop spinning
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        // Disable the Animator to freeze the current animation frame
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = false;
        }

        // Set the squished sprite
        spriteRenderer.sprite = squishedSprite;

        // Instantiate blood effect as a child of the insect
        if (bloodEffectPrefab != null)
        {
            GameObject blood = Instantiate(bloodEffectPrefab, transform.position, Quaternion.identity);
            blood.transform.parent = transform; // Make blood a child of the insect
        }

        // Disable collider to prevent further interactions
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Destroy the insect after a short delay
        Destroy(gameObject, 0.7f);
    }
}
