using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teletubbies : MonoBehaviour
{
    public GameObject teletubbie1, teletubbie2, tubbieBox, finishScherm;
    private int conversationPlus;

    public TMP_Text text;

    public TimerEindLevel tel;
    public Convo teletubLevend, teletubDood;
    public Wasd wasd;
    public FinishEindLevel teletoby;

    private void Update()
    {
        if (tel.teletubbieSpriteLevend.activeInHierarchy)
        {
            text.text = teletubLevend.convoText[conversationPlus];
        }
        else if (tel.teletubbieSpriteDood.activeInHierarchy)
        {
            text.text = teletubDood.convoText[conversationPlus];
        }

        if (finishScherm.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tubbieBox.gameObject.SetActive(true);
            wasd.enabled = false;
            teletoby.crossedFinish = true;

            if (tel.teletubbieSpriteLevend.activeInHierarchy)
            {
                teletubbie1.SetActive(true);
            }
            else if (tel.teletubbieSpriteDood.activeInHierarchy)
            {
                teletubbie2.SetActive(true);
            }
        }
    }

    public void TubbieConvo(InputAction.CallbackContext context)
    {
        if(teletubbie1.activeInHierarchy || teletubbie2.activeInHierarchy)
        {
            if (context.performed)
            {
                if (tel.teletubbieSpriteLevend.activeInHierarchy)
                {
                    if (conversationPlus < teletubLevend.convoText.Length - 1)
                    {
                        conversationPlus += 1;
                    }
                    else
                    { 
                        text.gameObject.SetActive(false);
                        conversationPlus = 0;

                        tubbieBox.SetActive(false);
                        finishScherm.SetActive(true);
                    }
                }
                else if (tel.teletubbieSpriteDood.activeInHierarchy)
                {
                    if (conversationPlus < teletubDood.convoText.Length - 1)
                    {
                        conversationPlus += 1;
                    }
                    else
                    {
                        wasd.enabled = true;
                        text.gameObject.SetActive(false);
                        conversationPlus = 0;

                        tubbieBox.SetActive(false);
                        finishScherm.SetActive(true);

                    }
                }
            }
        }
        
    }
}
