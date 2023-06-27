using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialScript : MonoBehaviour
{
    public TMP_Text w, s;
    public GameObject tutorialPanel;
    public bool wKlaar, sKlaar;

    private void Start()
    {
        w.gameObject.SetActive(true);
        s.gameObject.SetActive(true);
        wKlaar = false;
        sKlaar = false;
    }

    private void Update()
    {
        if(wKlaar && sKlaar)
        {
            tutorialPanel.SetActive(false);
            print("ga uit kutding");
        }
    }

    public void TutorialW(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(TutorialTijdW());
        }
    }

    public void TutorialS(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(TutorialTijdS());
        }
    }

    private IEnumerator TutorialTijdW()
    {
        yield return new WaitForSeconds(1.5f);
        w.gameObject.SetActive(false);
        wKlaar = true;
    }
    private IEnumerator TutorialTijdS()
    {
        yield return new WaitForSeconds(1.5f);
        s.gameObject.SetActive(false);
        sKlaar = true;
    }
}
