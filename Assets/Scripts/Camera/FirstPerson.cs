using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPerson : MonoBehaviour
{
    public float sensitivity = 1f;
    public Transform playerBody;

    public Wasd wasd;

    public Camera firstPerson, thirdPerson;

    private void Awake()
    {
        firstPerson.enabled = false;
        thirdPerson.enabled = true;
    }

    void Update()
    {
        float rotation = wasd.Rotation();
        playerBody.Rotate(Vector3.up * rotation * sensitivity);
        // playerBody.localRotation = Quaternion.Euler(0f, rotation, 0f);
        /*
         mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
         mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

         playerBody.Rotate(Vector3.up * mouseX);
            
         clamp -= mouseY;
         clamp = Mathf.Clamp(clamp, -90, 90);
         transform.localRotation = Quaternion.Euler(clamp, 0f, 0f);
        */
    }

    public void SwitchCamera (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            firstPerson.enabled = !firstPerson.enabled;
            thirdPerson.enabled = !thirdPerson.enabled;

            /*
            if (firstPerson.enabled)
            {
                firstPerson.enabled = false;
                thirdPerson.enabled = true;
            } else
            {
                firstPerson.enabled = true;
                thirdPerson.enabled = false;
            }
            */
        }
    }
}
