using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public bool crossedFinish;
    public GameObject finishScherm;

    private void Start()
    {
        crossedFinish = false;
        finishScherm.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        crossedFinish = true;
        finishScherm.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;

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
