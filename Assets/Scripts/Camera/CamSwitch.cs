using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject first, third;
    bool thirdOn;

    private void Start()
    {
        third.SetActive(false);
        thirdOn = false;
    }

    void Update()
    {
        if (thirdOn == false && Input.GetMouseButtonDown(0))
        {
            first.SetActive(false);
            third.SetActive(true);
            thirdOn = true;
        }
        else if (thirdOn == true && Input.GetMouseButtonDown(0))
        {
            first.SetActive(true);
            third.SetActive(false);
            thirdOn = false;
        }
    }
}
