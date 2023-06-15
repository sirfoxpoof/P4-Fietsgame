using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int neededLevels;
    //deze int is voor de if statement. als je level 2 wil doen moet 1 namelijk klaar zijn.
    private Button eindLevelButton;

    void Start()
    {
        eindLevelButton = GetComponent<Button>();
        // hebben variable aangemaakt zodat we de button interactable kunnen maken. zo kun je het eindlevel spelen.
        if(PlayerPrefs.GetInt("levelsDone") >= neededLevels)
        {
            eindLevelButton.interactable = true;
        }
    }

}
