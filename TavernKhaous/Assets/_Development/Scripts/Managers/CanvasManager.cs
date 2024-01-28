using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] CanvasGroup orderGroup;

    public static Action<bool> enableWalk;
    public static Action<bool> enableDrag;

    public List<int> idOrderList = new();

    private void OnEnable()
    {
        OrderButton.orderId = AddOrder;
    }

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

    public void OrderMenu()
    {
        enableDrag?.Invoke(true);
        HideOrderMenu();
    }

    void AddOrder(int id)
    {
        idOrderList.Add(id);
    }

    public void ClearOrder()
    {
        idOrderList.Clear();
    }
}
