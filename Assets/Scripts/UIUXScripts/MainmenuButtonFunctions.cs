using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuButtonFunctions : MonoBehaviour
{
    public GameObject loadingCanvas, mainMenuCanvas;
    public Slider loadprogressSlider;
    public float progressValue;

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quits game");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("TutorialLevelScene");
        PlayerPrefs.SetInt("dialougeKlaar", 0);

    }
    public void StartEindLevel()
    {
        SceneManager.LoadScene("EindLevelScene");

    }

    public void LoadLevelButton(string levelToLoad)
    {
        mainMenuCanvas.SetActive(false);
        loadingCanvas.SetActive(true);
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        loadOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(2f);
        loadOperation.allowSceneActivation = true;
        

        while (!loadOperation.isDone)
        {
            
            progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadprogressSlider.value = progressValue;
            Debug.Log(progressValue);
            yield return new WaitForSeconds(3f);
            

        }      
    }

}
    
