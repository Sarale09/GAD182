using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWA_InsectAIMovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rigidbody;

    private Vector2 targetDirection;

    private Transform bread;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        // Automatically find the bread by tag
        GameObject breadObject = GameObject.FindWithTag("Bread");
        if (breadObject != null)
        {
            bread = breadObject.transform;
        }
        else
        {
            Debug.LogError("Bread object not found in the scene. Ensure it has the tag 'Bread'.");
        }
    }

    private void FixedUpdate()
    {
        if (bread == null) return; // Stop if bread is not assigned
        UpdateToTargetDirection();
        RotateToTarget();
        SetVelocity();
    }

    private void UpdateToTargetDirection()
    {
        targetDirection = (bread.position - transform.position).normalized;
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
}
