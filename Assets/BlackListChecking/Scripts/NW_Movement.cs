using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_Movement : MonoBehaviour
{
    public float speed;
    public bool inPosition;
    public bool isChecked;
    
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if (!inPosition)
        {
            MoveRight();
            if (transform.position.x >= 2 && !isChecked)
            {
                Debug.Log("Character is now in the front of the line.");
                inPosition = true;
                isChecked = true;
            
                StartCoroutine(WaitingInput(KeyCode.Space));
            }
        }
        
    }

    private IEnumerator SecurityCheck()
    {
        yield return new WaitForSeconds(1f);
        
        Debug.Log("Let them in?");

        yield return WaitingInput(KeyCode.Space);

    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private IEnumerator WaitingInput(KeyCode key)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inPosition = false;
        }
        yield return null;
    }
}
