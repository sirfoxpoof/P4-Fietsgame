using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimerEindLevel : MonoBehaviour
{
    public TMP_Text timerText;
    public float startTime, time;
    public string minutes, seconds;
    public FinishEindLevel finishScript;
    public GameObject teletubbieSpriteDood, teletubbieSpriteLevend;



    void Start()
    {
        startTime = Time.time;
        teletubbieSpriteLevend.SetActive(true);
        teletubbieSpriteDood.SetActive(false);

    }

    public void Update()
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

            if (minutes == "2")
            {
                teletubbieSpriteLevend.SetActive(false);
                teletubbieSpriteDood.SetActive(true);
            }

        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TeletubbieFinish"))
        {
            if (teletubbieSpriteLevend == true )
            {

            }
            else if(teletubbieSpriteDood == true)
            {

            }
        }
    }

    public void TimerSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            minutes = "2";
            

            
        }

    }


}
