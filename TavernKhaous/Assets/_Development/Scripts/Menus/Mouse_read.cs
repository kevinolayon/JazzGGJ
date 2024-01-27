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
        image.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.SetActive(false);
    }
}
