using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float sensitivity = 100, mouseX, mouseY, clamp = 0;
    public Transform playerBody, cam;


    // Update is called once per frame
    void Update()
    {
         mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
         mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

         playerBody.Rotate(Vector3.up * mouseX);

         clamp -= mouseY;
         clamp = Mathf.Clamp(clamp, -90, 90);
         transform.localRotation = Quaternion.Euler(clamp, 0f, 0f);

        
    }
}

