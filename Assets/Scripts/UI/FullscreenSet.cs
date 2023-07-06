using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenSet : MonoBehaviour
{
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        print("fullscreen toggle");
    }
    

}
