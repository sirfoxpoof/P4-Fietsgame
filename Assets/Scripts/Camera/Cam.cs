using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cam : MonoBehaviour
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
