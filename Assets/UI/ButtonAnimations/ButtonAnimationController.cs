using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationController : MonoBehaviour
{
    public Animator StartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.Play("Normal", 0, 0.0f);

    }
}

