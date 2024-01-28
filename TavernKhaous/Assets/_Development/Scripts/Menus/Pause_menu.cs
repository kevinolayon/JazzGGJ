using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject Optionsmenu;

    private bool Paused = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Paused == false){
          Pause();
          Paused = true;
        }

    }

    public void Pause(){
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Whoosh"), Vector3.zero, value);
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue(){
        Paused = false;
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click_negativo"), Vector3.zero, value);
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click_negativo"), Vector3.zero, value);
        SceneManager.LoadScene("Start_Menu");
        
    }
    public void Options(){
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        Optionsmenu.SetActive(true);
        Pausemenu.SetActive(false);
        
    }
}
