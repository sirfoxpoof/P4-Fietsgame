using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiePlayer : MonoBehaviour
{
    public Animator windWhoooo;
    void Start()
    {
        windWhoooo.Play("WindAnimatie");
    }
}
