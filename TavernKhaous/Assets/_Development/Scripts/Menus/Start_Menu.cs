using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Kevin");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Language()
    {
        SceneManager.LoadScene("Language");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
