using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Wasd wasd;

    //wanneer we een object raken
    //krijgen info over de collision en daarom naam collisionInfo
    private void OnCollisionEnter (Collision collisionInfo)
    {
        if(collisionInfo.GetComponent<Collider>().tag == "obstacle")
        {
            wasd.enabled = false;
        }
    }
}
