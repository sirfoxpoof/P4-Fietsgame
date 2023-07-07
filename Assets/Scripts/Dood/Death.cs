using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Wasd wasd;
    public GameObject deathScreen, fietssprite1, fietssprite2, waterDoodScreen, andereKantScreen, verdwaaldScreen;
    public Transform respawn, player, cam;
    public AudioSource nearDeathSound, realDeath, waterDood, verdwaaldDeath;

    public bool dood, respawnn;

    private int lives = 1;

    public string sceneName;


    public TutorialScript tuut;
    public ConvoManager convo;
    private void Start()
    {
        deathScreen.SetActive(false);
        fietssprite1.SetActive(true);
        fietssprite2.SetActive(true);

        dood = false;

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

    }//canvas staat standaard uit

    private void Update()
    {
        if (lives < 0)
        {
            lives = 0;

            if (lives == 0)
            {
                wasd.serialPort.Close();
                wasd.enabled = false;
                deathScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                dood = true;
            }
        }

        if(sceneName == "TutorialLevelScene")
        {
            if (dood)
            {
                PlayerPrefs.SetInt("TutorialShow", 0);

                if (PlayerPrefs.GetInt("TutorialShow") < convo.toturial && convo.convoDone)
                {
                    tuut.tutorialPanel.gameObject.SetActive(false);
                }
            }
        }
           
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NearDeath"))
        {
            lives -= 1;
            fietssprite2.SetActive(false);
            nearDeathSound.Play();

        }
    }

    public void HitATreeDirtyFix()
    {
        lives -= 1;
        fietssprite2.SetActive(false);
        nearDeathSound.Play();
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            deathScreen.SetActive(true);
            wasd.serialPort.Close();
            wasd.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            realDeath.Play();

            dood = true;
        }

        else if (collisionInfo.collider.tag == "WaterDood")
        {
            wasd.serialPort.Close();
            wasd.enabled = false;
            waterDoodScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            waterDood.Play();

            dood = true;

        }

        else if (collisionInfo.collider.tag == "AndereKantOp")
        {
            wasd.serialPort.Close();
            wasd.enabled = false;
            andereKantScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            dood = true;

        }

        else  if (collisionInfo.collider.tag == "Verdwaald")
        {
            wasd.serialPort.Close();
            wasd.enabled = false;
            verdwaaldScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            verdwaaldDeath.Play();

            dood = true;

        }
    }

    public void RespawnButton()
    {
        player.transform.position = respawn.position;
        wasd.enabled = true;
        deathScreen.GetComponent<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.transform.eulerAngles = new Vector3(0, 180, 0);
        cam.transform.rotation = Quaternion.Euler(0, 180, 0);
        respawnn = true;

    }
    
}
