using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class HE_RepairClick : MonoBehaviour
{
    public Color red;
    public Color blue;
    public bool isFixed;
    public List<GameObject> holesPatched = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void OnMouseDown()
    {
        MeshRenderer mR = GetComponent<MeshRenderer>();
        mR.material.color = blue;
        holesPatched.Add(gameObject);



    }

}
