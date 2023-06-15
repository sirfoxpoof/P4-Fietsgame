using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSave : MonoBehaviour
{
    public void SaveGone()
    {
        PlayerPrefs.SetInt("LevelsDone", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
