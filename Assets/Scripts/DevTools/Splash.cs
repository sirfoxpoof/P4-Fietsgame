using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    
    private void Start()
    {
        StartCoroutine(SplashScreen());
        
    }
    public IEnumerator SplashScreen()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("MainMenu");
    }

    public void SkippySplashy(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
