using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public bool crossedFinish;
    public GameObject finishScherm;
    public Animator fietsJump;

    private void Start()
    {
        crossedFinish = false;
        finishScherm.SetActive(false);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        crossedFinish = true;
        finishScherm.SetActive(true);
        fietsJump.Play("WinAnimatie");



    }

    public void NaarSelectieScherm()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void LevelOpnieuwSpelen()
    {
        SceneManager.LoadScene("TutorialLevelScene");
        Time.timeScale = 1;
    }



}
