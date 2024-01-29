using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using System.Drawing;
public class Options_Menu : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject Optionsmenu;

    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    private bool gamestart;
    Resolution[] resolutions;
    void Start()
    {
        gamestart = true;
        SetVolume(1);
        resolutions = Screen.resolutions; 
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        gamestart = false;
    }
    public void SetVolume(float volume)
    {
        float value;
        if (gamestart == false){
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Whoosh"), Vector3.zero, value);
        }
        float newvolume = volume * 100f - 80f;
        audioMixer.SetFloat("volume", newvolume);
    }

    public void SetQuality(int qualityIndex)
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Setfullscreen(bool isFullscreen)
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        Screen.fullScreen = isFullscreen;
    }

    public void Setresolution(int resolutionIndex)
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }
    public void Options()
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click_negativo"), Vector3.zero, value);
        Optionsmenu.SetActive(false);
        Pausemenu.SetActive(true);
    }
}
