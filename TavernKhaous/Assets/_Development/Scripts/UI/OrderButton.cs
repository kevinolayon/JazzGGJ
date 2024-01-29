using System;
using UnityEngine;

public class OrderButton : MonoBehaviour
{
    public static Action<int> orderId;
    public void Order(int id)
    {
        SoundManager.Instance.audioMixer.GetFloat("volume", out float value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("Click"), Vector3.zero, value);
        orderId?.Invoke(id);
    }
}
