using UnityEngine;

public class InteractableOrderMenu : MonoBehaviour, IInteractable
{
    CanvasManager canvas;

    bool canOrder;

    private void Start()
    {
        canvas = CanvasManager.Instance;
    }

    public void Interact()
    {
        if (!canOrder) return;

        canvas.ShowOrderMenu();
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("cardapio"), Vector3.zero, value);   
    }
}
