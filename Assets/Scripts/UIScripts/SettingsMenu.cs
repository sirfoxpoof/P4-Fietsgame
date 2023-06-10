using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel, RUSure;

    public void Start()
    {
        settingsPanel.gameObject.SetActive(false);
        RUSure.SetActive(false);
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

    public void USureBuddy()
    {
        RUSure.SetActive(true);
    }

    public void TerugNaarMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
