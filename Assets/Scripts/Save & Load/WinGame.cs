using UnityEngine;

public class WinGame : MonoBehaviour
{
    bool gameWon = false;

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "finish")
        {
            gameWon = true;
        }
    }

    private void Update()
    {
        
    }
}
