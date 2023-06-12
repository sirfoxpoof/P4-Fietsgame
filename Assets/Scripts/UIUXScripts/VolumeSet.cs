using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSet : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetVolumeLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

    }

    public void SetVolumeLevelGame(float sliderValue)
    {
        mixer.SetFloat("GameVolume", Mathf.Log10(sliderValue) * 20);

    }

}
