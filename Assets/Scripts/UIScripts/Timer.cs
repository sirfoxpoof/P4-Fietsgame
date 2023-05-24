using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float startTime, time;
    public string minutes, seconds;

    void Start()
    {
        startTime = Time.deltaTime;
    }

    void Update()
    {
        time = Time.time - startTime;

        minutes = ((int)time / 60).ToString();
        seconds = (time % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;
    }

}
