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

    public TMP_Text text;
    private int conversationPlus;

    // Start is called before the first frame update
    void Start()
    {
        wasd.enabled = false;
        timer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = convo.convoText[conversationPlus];
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
                dialougebalk.SetActive(false);
            }
        }
    }
}
