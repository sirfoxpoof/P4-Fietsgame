using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public bool crossedFinish;

    private void Start()
    {
        crossedFinish = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        crossedFinish = true;

    }

}
