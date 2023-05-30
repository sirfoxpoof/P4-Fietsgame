using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Wasd : MonoBehaviour
{
    public float speed, speedIncrement, sensitivity;
    public Rigidbody rb;

    private bool increaseSpeed = false;
    private bool decreaseSpeed = false;
    public bool movementOn = true;

    private PlayerInput playerInput;
    private InputAction rotation;


    private void Awake()
    {
        playerInput = new PlayerInput();
        rotation = playerInput.Default.Rotation;
       
    }

    private void Start()
    {
        movementOn = true;
    }

    private void OnEnable()
    {
        rotation.Enable();
    }

    private void OnDisable()
    {
        rotation.Disable();
    }

    void Update()
    {
        if (movementOn)
        {
            if (increaseSpeed)
            {
                if (speed < 100f)
                {
                    speed += speedIncrement;
                }
            }
            else
            {
                if (speed > 0f)
                {
                    speed -= speedIncrement;
                }
            }

            if (decreaseSpeed)
            {
                if (speed > -100)
                {
                    speed -= speedIncrement;
                }
            }
            else
            {
                if (speed < 0)
                {
                    speed += speedIncrement;
                }
            }

            transform.Translate(transform.forward * speed * sensitivity * Time.deltaTime, Space.World);
        }
       
    }

    public void Forward (InputAction.CallbackContext context)
    {
        if (movementOn)
        {
            if (context.started)
            {
                increaseSpeed = true;
            }

            if (context.canceled)
            {
                increaseSpeed = false;
            }      
        }
        
    }

    public void Backward (InputAction.CallbackContext context)
    {
        if (movementOn)
        {
            if (context.started)
            {
                decreaseSpeed = true;
            }

            if (context.canceled)
            {
                decreaseSpeed = false;
            }
        }
    }

    public float Rotation ()
    {
        return rotation.ReadValue<Vector2>().x;
    }
}
