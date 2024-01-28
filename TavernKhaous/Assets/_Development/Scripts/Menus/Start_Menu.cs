using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    public void StartGame()
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        SceneManager.LoadScene("Game");
    }
    public void Credits()
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        SceneManager.LoadScene("Credits");
    }
    public void Language()
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        SceneManager.LoadScene("Language");
    }
    public void QuitGame()
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        Application.Quit();
    }
}
