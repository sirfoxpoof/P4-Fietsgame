using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackDumbass : MonoBehaviour
{
    public Wasd wasd;
    public GameObject terug;

    public void Start()
    {
        terug.SetActive(false);
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "GaTerug")
        {
            wasd.enabled = false;
            terug.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
