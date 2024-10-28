using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HE_RepairClick : MonoBehaviour
{
    public GameObject hole;
    public GameObject patch;
    public Camera mCamera;
    RaycastHit raycastHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    public void OnClick()
    {
        Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
        int layerMask = LayerMask.GetMask("Enviroment");
        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
        {

        }
    }



}
