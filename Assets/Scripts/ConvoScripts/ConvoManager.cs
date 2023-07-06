using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConvoManager : MonoBehaviour
{
    public Wasd wasd;
    public Convo convo;
    public Timer timer;
    public GameObject dialougebalk;

    public TMP_Text text, space;
    private int conversationPlus;

    public bool convoDone;
    public int byeDialouge, toturial;

    public TutorialScript tutorialScript;
    public Death death;
    public FinishLine finishLine;

    // Start is called before the first frame update
    void Start()
    {
        wasd.enabled = false;
        timer.enabled = false;
        tutorialScript.enabled = false;

        convoDone = false;

        PlayerPrefs.SetInt("TutorialShow", 1);
    }

    // Update is called once per frame
    void Update()
    {

        text.text = convo.convoText[conversationPlus];
        
        if(PlayerPrefs.GetInt("dialougeKlaar") == byeDialouge)
        {
           convoDone = true;
        }

        if (convoDone && !death.dood && !finishLine.finnish)
        {
            dialougebalk.SetActive(false);
            wasd.enabled = true;
            timer.enabled = true;
            tutorialScript.enabled = true;
            tutorialScript.tutorialAan = true;

            if(!tutorialScript.wKlaar && !tutorialScript.sKlaar)
            {
                tutorialScript.w.gameObject.SetActive(true);
                tutorialScript.s.gameObject.SetActive(true);
            }
            
        }

        if (!convoDone)
        {
            PlayerPrefs.SetInt("TutorialShow", 0);
        }

        if (PlayerPrefs.GetInt("TutorialShow") == toturial)
        {
            tutorialScript.tutorialPanel.gameObject.SetActive(true);
        }

    }

    public void ConvoNext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (conversationPlus < convo.convoText.Length - 1)
            {
                conversationPlus += 1;
            }
            else
            {
                wasd.enabled = true;
                text.gameObject.SetActive(false);
                conversationPlus = 0;
                
                
                tutorialScript.enabled = true;
                tutorialScript.tutorialPanel.SetActive(true);
                dialougebalk.SetActive(false);

                PlayerPrefs.SetInt("dialougeKlaar", 1);
                
            }

            if(conversationPlus == 0)
            {
                space.gameObject.SetActive(true);
                space.text = ("druk op de spatiebalk om verder te gaan");
            }
            else
            {
                space.gameObject.SetActive(false);  
            }
        }
    }
}
