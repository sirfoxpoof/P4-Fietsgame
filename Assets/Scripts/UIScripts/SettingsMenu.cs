using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public void Start()
    {
        settingsPanel.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        settingsPanel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;


    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        settingsPanel.gameObject.SetActive(false);
        
    }

}
