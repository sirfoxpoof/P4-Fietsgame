using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuButtonFunctions : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quits game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("DaniqueTestScene");

    }
}
    
