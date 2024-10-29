using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        GameObject breadObject = GameObject.FindWithTag("Bread");
        if (breadObject != null)
        {
            bread = breadObject.transform;
        }
    }

    private void FixedUpdate()
    {
        if (bread == null) return;
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Insect"))
        {
            Debug.Log("Insect has collided with the bread.");
        }
    }
}
