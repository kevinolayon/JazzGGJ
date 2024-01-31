using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    [SerializeField] CanvasGroup credits;
    public void StartGame()
    {
        SoundManager.Instance.audioMixer.GetFloat("volume", out float value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        SceneManager.LoadScene("Game");
    }
    public void Credits()
    {
        SoundManager.Instance.audioMixer.GetFloat("volume", out float value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        credits.DOFade(1, .25f);
        credits.blocksRaycasts = true;
        credits.interactable = true;
        //SceneManager.LoadScene("Credits");
    }

    public void CloseCredits()
    {
        SoundManager.Instance.audioMixer.GetFloat("volume", out float value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        credits.DOFade(0, .25f);
        credits.blocksRaycasts = false;
        credits.interactable = false;

    }
    public void Language()
    {
        SoundManager.Instance.audioMixer.GetFloat("volume", out float value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        //SceneManager.LoadScene("Language");
    }
    public void QuitGame()
    {
        SoundManager.Instance.audioMixer.GetFloat("volume", out float value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        Application.Quit();
    }
}
