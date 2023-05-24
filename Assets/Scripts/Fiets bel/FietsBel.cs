using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Cinemachine.CinemachineOrbitalTransposer;

public class FietsBel : MonoBehaviour
{
    public AudioSource belDing;
    public ParticleSystem belVisual;


    public void Bel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            belDing.pitch = Random.Range(0.85f, 1.15f);
            belDing.Play();
            belVisual.Play();
        }
        
    }
}
