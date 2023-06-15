using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSave : MonoBehaviour
{   
    public void SaveGone()
    {
        PlayerPrefs.SetInt("levelsDone", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
