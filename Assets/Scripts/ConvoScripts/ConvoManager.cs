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

    private bool convoDone;
    public int byeDialouge;

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
                timer.enabled = true;
                
                tutorialScript.enabled = true;
                tutorialScript.tutorialPanel.SetActive(true);
                dialougebalk.SetActive(false);

                PlayerPrefs.SetInt("dialougeKlaar", 1);
                
            }

            if(conversationPlus == 0)
            {
                space.gameObject.SetActive(true);
                space.text = ("Press space bar to continue");
            }
            else
            {
                space.gameObject.SetActive(false);  
            }
        }
    }
}
