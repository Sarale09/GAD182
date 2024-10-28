using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HE_MouseController_BarFight : MonoBehaviour
{
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
    }

    




}
   



