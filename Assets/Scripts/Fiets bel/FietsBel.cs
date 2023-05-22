using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FietsBel : MonoBehaviour
{
    public AudioSource belDing;
    public ParticleSystem belVisual;


    public void Bel(InputAction.CallbackContext context)
    {
        belDing.Play();
        belVisual.Play();
    }
}
