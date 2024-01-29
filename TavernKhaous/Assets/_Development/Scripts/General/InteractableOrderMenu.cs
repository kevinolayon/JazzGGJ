using UnityEngine;

public class InteractableOrderMenu : MonoBehaviour, IInteractable
{
    CanvasManager canvas;

    bool canOrder;

    private void Start()
    {
        canvas = CanvasManager.Instance;
    }

    private void OnEnable()
    {
        CanvasManager.canOrder += EnableOrder;
        DialogManager.onEndDialog += EnableOrder;
    }

    private void OnDisable()
    {
        CanvasManager.canOrder -= EnableOrder;
        DialogManager.onEndDialog -= EnableOrder;
    }

    public void Interact()
    {
        if (!canOrder) return;

        canvas.ShowOrderMenu();
        SoundManager.Instance.audioMixer.GetFloat("volume", out float value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("cardapio"), Vector3.zero, value);   
    }

    void EnableOrder(bool value)
    {
        canOrder = value;
    }

    void EnableOrder()
    {
        canOrder = true;
    }
}
