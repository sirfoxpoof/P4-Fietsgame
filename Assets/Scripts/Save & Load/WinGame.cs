using UnityEngine;

public class WinGame : MonoBehaviour
{
    public bool gameWon = false;

    public int levelNumberSave;

    public Wasd wasd;
    private void OnCollisionEnter(Collision other)
    {
        gameWon = true;
        wasd.enabled = false;
        print("you win");
    }

    private void Update()
    {
        if (gameWon)
        {
            if(PlayerPrefs.GetInt("levelsDone") < levelNumberSave)
            {
                PlayerPrefs.SetInt("levelsDone", levelNumberSave);
            }
        }
    }
}
