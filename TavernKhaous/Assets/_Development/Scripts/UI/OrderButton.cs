using System;
using UnityEngine;

public class OrderButton : MonoBehaviour
{
    public static Action<int> orderId;
    public void Order(int id)
    {
        orderId?.Invoke(id);
    }
}
