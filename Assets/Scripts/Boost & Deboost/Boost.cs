using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public Wasd speedScript;
    float boostSpeed, deBoostSpeed;
    RaycastHit boDeBo;


    private void Start()
    {
        boostSpeed = 8;
        deBoostSpeed = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, -transform.up, out boDeBo, 1) && gameObject.CompareTag("Boost"))
        {
            speedScript.speed = boostSpeed; 
        }
        if (Physics.Raycast(transform.position, -transform.up, out boDeBo, 1) && gameObject.CompareTag("Deboost"))
        {
            speedScript.speed = deBoostSpeed;
        }
    }
}
