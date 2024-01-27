using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject Optionsmenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
          Pause();
        }

    }

    public void Pause(){
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue(){
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        SceneManager.LoadScene("Start_Menu");
    }
    public void Options(){
        Optionsmenu.SetActive(true);
        Pausemenu.SetActive(false);
    }
}
