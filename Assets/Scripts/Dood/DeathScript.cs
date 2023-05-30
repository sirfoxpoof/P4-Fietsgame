using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public Transform respawn, player;
    public Collider deathCollider;
    public Wasd wasd;
    public Canvas deathScreen;

    private void CollisionEnter(Collision deathcollider)
    {
        wasd.movementOn = false;
        player.position = respawn.position;

        if (!wasd.movementOn)
        {
            deathScreen.enabled = true;
        }
        else
        {
            deathScreen.enabled = false;
        }
    }
}
