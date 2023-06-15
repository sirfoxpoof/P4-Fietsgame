using UnityEngine;

public class WinGame : MonoBehaviour
{
    public bool gameWon = false;

    public int levelNumberSave;

    public Wasd wasd;
    private void OnCollisionEnter(Collision other)
    {
        if( other.collider.tag == "Player")
        {
            gameWon = true;
            wasd.enabled = false;
            print("you win!");
        }
    }

    private void Update()
    {
        if (gameWon)
        {
            print("gameWOn is true");
            if(PlayerPrefs.GetInt("levelsDone") < levelNumberSave)
            {// we willen alleen overwriten als je minder levels gedaan hebt dan je hebt. als je dan het level klaar hebt mag hij overwriten om het volgende level te spelen.
                PlayerPrefs.SetInt("levelsDone", levelNumberSave);
                //zetten een int naar hoeveel levels van levelNumberSave klaar zijn.
            }
        }
    }
}
