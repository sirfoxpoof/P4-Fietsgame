using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speedBoost;
    private bool boostTrue = false;

    private Wasd wasd;

    private void Update()
    {
        if (boostTrue)
        {
            wasd.speed = speedBoost;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WindBoost();
        }
    }

    private void WindBoost()
    {
        print("WEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        boostTrue = true;
    }
}
