using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    Resolution[] resolutionIndex;
    
    public TMP_Dropdown resolutionDropdown;
    
    

    void Start()
    {
        resolutionIndex = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutionIndex.Length; i++)
        {
            string option = resolutionIndex[i].width + "x" + resolutionIndex[i].height;
            options.Add(option);

            if (resolutionIndex[i].width == Screen.currentResolution.width && resolutionIndex[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        

    }

}//resolutionDropdown.AddOptions();
