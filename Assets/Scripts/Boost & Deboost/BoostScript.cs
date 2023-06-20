using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    public float mudDeboost;
    public float speedBoost;
    public Wasd wasd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mud"))
        {
            wasd.speed *= mudDeboost;
            wasd.boostFactor *= .5f;
        }

        if (other.CompareTag("Wind"))
        {
            wasd.speed += speedBoost;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mud"))
        {
            wasd.boostFactor = 1f;
        }

        if (other.CompareTag("Wind"))
        {
            wasd.speed -= speedBoost;
        }
    }
}
