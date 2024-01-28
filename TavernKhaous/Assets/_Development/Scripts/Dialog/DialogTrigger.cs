using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool hasDialogStarted = false;

    [SerializeField]
    private SODialog dialog;

    [SerializeField]
    private SOClient client;

    [SerializeField]
    private KeyCode _dialogKey;

    public void OnTriggerEnter(Collider other)
    {
       
    }

    public void OnTriggerStay(Collider other)
    { 
        if (dialog != null)
        {
            if (!hasDialogStarted && Input.GetKeyDown(_dialogKey))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Trigger Player");
                    hasDialogStarted = true;
                    GameManager.Instance.DialogManager.DialogStart(dialog.root);
                }
            }           
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GameManager.Instance.DialogManager.OnEndDialog();
        hasDialogStarted = false;    
    }
}
