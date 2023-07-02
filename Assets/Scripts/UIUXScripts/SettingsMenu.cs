using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel, RUSure;
    public bool settingsAan = false;

    public ConvoManager convo;

    public void Start()
    {
        settingsPanel.gameObject.SetActive(false);
        RUSure.SetActive(false);
    }

  
    public void DoSettingsMenu (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!settingsAan)
            {
                SettingsMenuOn();
            }
            
            else
            {
                SettingsMenuOff();
            }
            settingsAan = !settingsAan;
        }
    }

    public void SettingsMenuOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        settingsPanel.gameObject.SetActive(true);
        Time.timeScale = 0;

        convo.dialougebalk.SetActive(false);
    }

    public void SettingsMenuOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        settingsPanel.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("dialougeKlaar") < convo.byeDialouge)
        {
            convo.dialougebalk.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        settingsPanel.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("dialougeKlaar") < convo.byeDialouge)
        {
            convo.dialougebalk.SetActive(true);
        }
            

    }

    public void USureBuddy()
    {
        RUSure.SetActive(true);
    }

    public void TerugNaarMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("dialougeKlaar", 0);
    }

    public void OpnieuwProberen()
    {
        SceneManager.LoadScene("TutorialLevelScene");
        Time.timeScale = 1;
    }



}
