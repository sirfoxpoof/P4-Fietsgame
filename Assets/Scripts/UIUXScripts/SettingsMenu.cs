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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            settingsPanel.gameObject.SetActive(true);
            
        }
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

    public void OpnieuwProberen()
    {
        SceneManager.LoadScene("TutorialLevelScene");
        Time.timeScale = 1;
    }



}
