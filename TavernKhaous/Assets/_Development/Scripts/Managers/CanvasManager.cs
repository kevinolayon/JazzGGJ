using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] Image image;

    public void ToggleImage()
    {
        image.enabled = !image.enabled;
    }

}
