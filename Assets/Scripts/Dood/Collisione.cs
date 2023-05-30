using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collisione : MonoBehaviour
{
    public Wasd wasd;
    public Canvas deathScreen;
    public MouseLock mousLock;
    public Transform respawn, player;


    private void Start()
    {
        deathScreen.GetComponent <Canvas> ().enabled = false;
    }
    //wanneer we een object raken
    //krijgen info over de collision en daarom naam collisionInfo
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            wasd.enabled = false;
            deathScreen.enabled = true;
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
    }
}
