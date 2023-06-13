using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float mudDeboost;
    public float speedBoost;
    public Wasd wasd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mud"))
        {
            StartCoroutine(MudBoost());
        }

        if (other.CompareTag("Wind"))
        {
            StartCoroutine(WindBoost());
        }


    }




    private IEnumerator MudBoost()
    {
        wasd.speed *= mudDeboost;
        wasd.boostFactor *= .5f;

        yield return new WaitForSeconds(1.5f);

        wasd.boostFactor = 1f;

    }
    private IEnumerator WindBoost()
    {
        wasd.speed += speedBoost;
        //wasd.specialControllerSpeed += speedBoost;

        yield return new WaitForSeconds(1.5f);

        wasd.speed -= speedBoost;
    }
}
