using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBoost : MonoBehaviour
{
    public float mudDeBoost;

    public Wasd wasd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MudBoost());
        }
    }


    private IEnumerator MudBoost()
    {
        wasd.speed -= mudDeBoost;

        yield return new WaitForSeconds(2.5f);

        wasd.speed += mudDeBoost;
    }

}
