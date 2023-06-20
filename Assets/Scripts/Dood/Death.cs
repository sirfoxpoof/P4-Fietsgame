using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO.Ports;


public class Death : MonoBehaviour
{
    public Wasd wasd;
    public GameObject deathScreen;
    public Transform respawn, player, cam;

    private int lives = 1;


    private void Start()
    {
        deathScreen.SetActive(false);
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
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NearDeath"))
        {
            lives -= 1;
        }
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            wasd.serialPort.Close();
            wasd.enabled = false;
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
    }
    
}
