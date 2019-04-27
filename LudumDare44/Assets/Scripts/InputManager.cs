using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public void Refresh()
    {
        Vector3 movementVector = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movementVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movementVector += Vector3.back;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movementVector += Vector3.right;            
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movementVector += Vector3.left;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            BloodBoy.instance.Spray();
        }


        if (movementVector != Vector3.zero)
        {
            BloodBoy.instance.Move(movementVector);
        }
    }
}
