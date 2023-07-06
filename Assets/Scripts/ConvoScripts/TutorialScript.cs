using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialScript : MonoBehaviour
{
    public TMP_Text w, s, fiets, muis, ontwijk;
    public GameObject tutorialPanel;
    private bool muisKlaar, fietsklaar;
    public bool tutorialAan, wKlaar, sKlaar;

    public int tutoBezig;

    public Wasd wasd;
    public ConvoManager convoManager;
   

    private void Awake()
    {
        if (wasd.specialControllerActive)
        {
            w.gameObject.SetActive(false);
            s.gameObject.SetActive(false);
            tutorialPanel.SetActive(false);
        }
        else if(!wasd.specialControllerActive && convoManager.convoDone) 
        {
            w.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
            tutorialPanel.SetActive(false);

            wKlaar = false;
            sKlaar = false;
            muisKlaar = false;
            tutorialAan = false;
        }
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("TutorialShow") == convoManager.toturial && convoManager.convoDone)
        {
            if (wasd.specialControllerActive && convoManager.convoDone)
            {
                tutorialPanel.SetActive(true);
                fiets.gameObject.SetActive(true);
                w.gameObject.SetActive(false);
                s.gameObject.SetActive(false);

                if (fietsklaar)
                {
                    fiets.gameObject.SetActive(false);
                }
            }
        }
       


        if (wKlaar && sKlaar)
        {
            muis.gameObject.SetActive(true);
            StopCoroutine(TutorialTijdS());
            StopCoroutine(TutorialTijdW());

            if (muisKlaar)
            {
                muis.gameObject.SetActive(false);
                StopCoroutine(TutorialMuis());
                ontwijk.gameObject.SetActive(true);
            }
        }

        if (wasd.specialControllerSpeed > 1)
        {
            StartCoroutine(Fietssss());
        }

    }

    public void TutorialW(InputAction.CallbackContext context)
    {
        if (convoManager.convoDone)
        {
            if (context.performed)
            {
                StartCoroutine(TutorialTijdW());
            }
        }
    }

    public void TutorialS(InputAction.CallbackContext context)
    {

        if (convoManager.convoDone)
        {
            if (context.performed)
            {
                StartCoroutine(TutorialTijdS());
            }
        }

    }

    public void CamGebruikt(InputAction.CallbackContext context)
    {
        if (convoManager.convoDone && wKlaar && sKlaar)
        {
            if (context.performed)
            {
                StartCoroutine(TutorialMuis());
            }
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
    
    private IEnumerator TutorialMuis()
    {
        yield return new WaitForSeconds(1.5f);
        muisKlaar = true;
    }

    private IEnumerator Fietssss()
    {
        yield return new WaitForSeconds(3f);
        fiets.gameObject.SetActive(false);
        sKlaar= true;
        wKlaar= true;
        fietsklaar = true;  
    }
}
