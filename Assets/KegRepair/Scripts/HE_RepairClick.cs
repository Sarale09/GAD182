using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HE_RepairClick : MonoBehaviour
{
    public Material broke;
    public Material fix;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Yo");
        gameObject.GetComponent<MeshRenderer>().material = broke;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {

                if (hit.collider.tag == "Hole")
                {
                    Debug.Log("Hit Register");
                    this.gameObject.GetComponent<MeshRenderer>().material = fix;
                }
               
            }
        }
    }
}
