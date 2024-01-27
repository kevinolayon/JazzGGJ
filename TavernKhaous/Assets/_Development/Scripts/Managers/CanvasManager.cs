using DG.Tweening;
using System;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] CanvasGroup orderGroup;

    public static Action<bool> enableWalk;

    private void Awake()
    {
        HideOrderMenu();
    }

    public void ShowOrderMenu()
    {
        enableWalk?.Invoke(false);
        orderGroup.DOFade(1, .25f);
        orderGroup.interactable = true;
        orderGroup.blocksRaycasts = true;
    }

    public void HideOrderMenu()
    {
        enableWalk?.Invoke(true);
        orderGroup.DOFade(0, .25f);
        orderGroup.interactable = false;
        orderGroup.blocksRaycasts = false;
    }
}
