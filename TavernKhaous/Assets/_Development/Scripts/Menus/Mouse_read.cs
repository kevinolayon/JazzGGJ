using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse_read : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject image;

    void Start()
    {
        image.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Whoosh"), Vector3.zero, value);
        image.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.SetActive(false);
    }
}
