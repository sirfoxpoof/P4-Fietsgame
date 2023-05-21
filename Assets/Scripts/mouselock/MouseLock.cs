using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLock : MonoBehaviour
{
    private bool lockMous;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lockMous = true;
    }
    public void MousLock (InputAction.CallbackContext context)
    {
        if(lockMous == false)
        {
            lockMous = true;
        }
        else
        {
            lockMous = false;
        }
        if (lockMous == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(lockMous == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        
    }
}
