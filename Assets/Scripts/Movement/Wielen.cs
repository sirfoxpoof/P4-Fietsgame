using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wielen : MonoBehaviour
{
    public GameObject wiel1, wiel2;
    public float wheelSpeed = 45;
    public Wasd wasd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float realWheelSpeed = wheelSpeed * Time.deltaTime;
        if (wasd.speed < -1)
        {
            realWheelSpeed = -realWheelSpeed;
        }

        if(Mathf.Abs(wasd.speed) > 1)
        {
            wiel1.transform.Rotate(realWheelSpeed, 0,0);
            wiel2.transform.Rotate(realWheelSpeed, 0,0);
        }
    }
}
