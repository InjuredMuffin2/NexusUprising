using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class Settings : MonoBehaviour
{
    public static Settings instance;

    public Slider musicVolume;
    public Slider audioVolume;
    public int frameRateLimit;

    public TMP_InputField targetFPS;

    public int targetWidth = 1920;
    public int targetHeight = 1080;
    public bool fullscreen = true;

    private void Awake()
    {
        instance = this;
        frameRateLimit = 60;
        SetTargetResolution();
    }
    private void Start()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        //ApplyMusicVolume();
        ApplyAudioVolume();

        Application.targetFrameRate = 60;

        if(targetFPS != null)
            targetFPS.text = "60";
    }

    // Apply the music volume setting
    public void ApplyMusicVolume()
    {
        if (musicVolume != null)
            PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
    }

    // Apply the audio volume setting
    public void ApplyAudioVolume()
    {
        if (audioVolume != null)
            PlayerPrefs.SetFloat("AudioVolume", audioVolume.value);
    }

    // Set the game's target framerate
    public void SetFramerate()
    {
        if (int.TryParse(targetFPS.text, out frameRateLimit))
        {
            PlayerPrefs.SetInt("TargetFPS", frameRateLimit);
        }
        else
        {
            Application.targetFrameRate = 60;
        }
        Application.targetFrameRate = PlayerPrefs.GetInt("TargetFPS");
    }

    private void SetTargetResolution()
    {
        Screen.SetResolution(targetWidth, targetHeight, fullscreen);
    }

}
