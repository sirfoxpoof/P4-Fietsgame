using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float startTime, time;
    public string minutes, seconds;
    public FinishLine finishScript;

    void Start()
    {
        startTime = Time.deltaTime;
        
    }

    private void Update()
    {
        if (finishScript.crossedFinish == true)
        {
            return;
        }
        
        else
        {
            time = Time.time - startTime;

            minutes = ((int)time / 60).ToString();
            seconds = (time % 60).ToString("f1");

            timerText.text = minutes + ":" + seconds;

            
        }

       
    }
}
