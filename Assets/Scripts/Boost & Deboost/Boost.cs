using System.Collections;
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
        wasd.speed -= mudDeboost;

        yield return new WaitForSeconds(2.5f);

    }
    private IEnumerator WindBoost()
    {
        wasd.speed += speedBoost;

        yield return new WaitForSeconds(1.5f);

        wasd.speed -= speedBoost;
    }
}
