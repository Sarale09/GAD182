using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HE_MouseController_BarFight : MonoBehaviour
{
    public float dragSpeed = 10f;
    private Vector3 offset;

    private void OnMouseDown()
    {
        // sets boundaries for how far the objects will move towards the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0);
    }
    private void OnMouseDrag()
    {   // grabs the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(mousePos.x, mousePos.y,0) + offset;
        // Prevents the object from passing the cameras view
        newPos = ClampPositionToCamera( newPos );
        // moves the objects 
        transform.position = newPos;
    }

    private Vector3 ClampPositionToCamera( Vector3 position)
    { // sets the cameras view area
        Camera mCam = Camera.main;
        float mCamHeight = mCam.orthographicSize * 2;
        float mCamWidth = mCamHeight * mCam.aspect;
        // "Clamps" the position withing the cameras view area
        position.x = Mathf.Clamp(position.x, mCam.transform.position.x - mCamWidth / 2, mCam.transform.position.x + mCamWidth / 2);
        position.y = Mathf.Clamp(position.y, mCam.transform.position.y - mCamHeight / 2, mCam.transform.position.y + mCamHeight / 2);
        return position;

    }





}
   



