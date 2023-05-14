using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasd : MonoBehaviour
{
    float hor, ver, speed;
    Vector3 movement;
    public Rigidbody rb;
  
    private void Start()
    {
        speed = 5;  
    }

    // Update is called once per frame
    void Update()
    {
         hor = Input.GetAxis("Horizontal");
         ver = Input.GetAxis("Vertical");

         movement.x = hor;
         movement.z = ver;

         transform.Translate(movement * speed * Time.deltaTime);
    }
}
