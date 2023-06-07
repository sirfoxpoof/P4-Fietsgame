using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speedBoost;

    public Wasd wasd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WindBoost());
        }
    }

    
    private IEnumerator WindBoost()
    {
        wasd.speed += speedBoost;

        yield return new WaitForSeconds(2.5f);

        wasd.speed -= speedBoost;
    }
}
