using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTwoMove : MonoBehaviour
{
    public GameObject customerTwo;
    public Transform customer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveToCTwo = customer.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, customer.position, speed * Time.deltaTime);
    }
}
