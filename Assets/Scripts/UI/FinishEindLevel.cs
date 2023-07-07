using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishEindLevel : MonoBehaviour
{
    public bool crossedFinish, finnish;
    //public GameObject finishScherm;
    //public Animator fietsJump;

   // public Slider loadprogressSlider;
    //public float progressValue;


    public ConvoManager convo;
    public TutorialScript tuto;

    private void Start()
    {
        crossedFinish = false;
        //finishScherm.SetActive(false);

        finnish = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //fietsJump.Play("WinAnimatie");
        crossedFinish = true;
        //finishScherm.SetActive(true);

        tuto.tutorialPanel.SetActive(false);
        finnish = true;

        PlayerPrefs.SetInt("TutorialShow", 0);

        if (PlayerPrefs.GetInt("TutorialShow") == convo.toturial && convo.convoDone)
        {
            tuto.tutorialPanel.gameObject.SetActive(false);
        }


    }

    public void NaarSelectieScherm(string levelToLoad)
    {
        SceneManager.LoadScene("MainMenu");
    }

   

    public void LevelOpnieuwSpelen()
    {
        SceneManager.LoadScene("EindLevelScene");
        Time.timeScale = 1;
        PlayerPrefs.SetInt("dialougeKlaar", 0);
    }



}


