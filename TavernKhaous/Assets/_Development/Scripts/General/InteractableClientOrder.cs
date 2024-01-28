using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableClientOrder : MonoBehaviour, IInteractable
{
    [SerializeField] SODialog dialog;
    public void Interact()
    {
        // Call dialog
        Debug.Log("Dialog");
        GameManager.Instance.DialogManager.DialogStart(dialog.root);
    }
}
