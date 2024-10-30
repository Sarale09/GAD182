using System.Collections;
using UnityEngine;

public class MWA_InsectAIMovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rigidbody;
    private Vector2 targetDirection;
    private Bread breadScript; // Reference to the Bread script

    private bool isEating = false; // Track if insect is currently eating

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        GameObject breadObject = GameObject.FindWithTag("Bread");
        if (breadObject != null)
        {
            breadScript = breadObject.GetComponent<Bread>();
        }
    }

    private void FixedUpdate()
    {
        if (breadScript == null) return;
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
        if (collision.gameObject.CompareTag("Bread"))
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
            yield return new WaitForSeconds(2f); // Wait for 2 second between each health reduction
        }
    }
}
