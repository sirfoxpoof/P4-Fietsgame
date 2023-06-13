using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System.IO.Ports;


public class Wasd : MonoBehaviour
{
    public float speed, speedIncrement, sensitivity;
    public Rigidbody rb;

    private bool increaseSpeed = false;
    private bool decreaseSpeed = false;
    private bool sCIncreaseSpeed = false;
    private bool sCDecreaseSpeed = false;

    public float boostFactor = 1f;

    private PlayerInput playerInput;
    private InputAction rotation;

    public float wheelFactor = 1f;

    private string rawData = "";
    private int wheelValue = 0;
    private int ringValue = 0;
    public float specialControllerSpeed = 0;
    private float specialControllerValue = 0;
    public float specialControllerSensitivity = 1;
    private bool specialControllerActive = false;

    // change your serial port
    public SerialPort serialPort = new SerialPort("COM5", 9600);


    private void Awake()
    {
        playerInput = new PlayerInput();
        rotation = playerInput.Default.Rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 100; // In my case, 100 was a good amount to allow quite smooth transition. praat fucking nederlands hoer
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
        if (serialPort.IsOpen)
        {
            try
            {
                rawData = serialPort.ReadLine();

                if (rawData.Length > 0)
                {
                    specialControllerActive = true;
                   
                    wheelValue = int.Parse(rawData.Substring(0, 1));
                    ringValue = int.Parse(rawData.Substring(1, 1));

                    // Speed
                    specialControllerValue = wheelValue * wheelFactor;

                    // Ring
                    int ring = ringValue;
                    if (ring == 1)
                    {
                        Debug.Log("Ring Ring!");
                    }
                } 
                else
                {
                    specialControllerActive = false;      
                }
            }
            catch (System.Exception)
            {
                specialControllerActive = false;
                Debug.LogWarning("Connection with Arduino could not be established!");
            }
        }

        if (!specialControllerActive)
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

        if (specialControllerActive)
        {

            if (specialControllerValue  < specialControllerSpeed)
            {
                specialControllerSpeed -= speedIncrement;
            }

            if (specialControllerValue > specialControllerSpeed)
            {
                specialControllerSpeed += speedIncrement;

            }

            transform.Translate(((transform.forward * specialControllerSpeed * specialControllerSensitivity) * boostFactor) * Time.deltaTime, Space.World);

        }


    }

    public void Forward (InputAction.CallbackContext context)
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

    public void Backward (InputAction.CallbackContext context)
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

    public float Rotation ()
    {
        return rotation.ReadValue<Vector2>().x;
    }
}
