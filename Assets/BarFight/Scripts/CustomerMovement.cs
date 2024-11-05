using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public GameObject customerOne;
    public Transform customerTwo;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveToCTwo = customerTwo.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, customerTwo.position, speed * Time.deltaTime);
    }

}
