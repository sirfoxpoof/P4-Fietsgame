using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Devtool1 : MonoBehaviour
{
    public GameObject player;
    public Vector3 finishPosition;


    public void TeleportPlayer(InputAction.CallbackContext context)
    {
        player.transform.position = finishPosition;
        
    }
    
}
