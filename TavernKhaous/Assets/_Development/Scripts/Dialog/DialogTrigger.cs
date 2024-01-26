using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool hasDialogStarted = false;

    [SerializeField]
    private SODialog dialog;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");

        if(dialog != null)
        {
            if (other.gameObject.CompareTag("Player") && !hasDialogStarted)
            {
                Debug.Log("Trigger Player");
                hasDialogStarted = true;
                GameManager.Instance.DialogManager.DialogStart(dialog.root, dialog.name);
            }
        }   
    }

    public void OnTriggerStay(Collider other)
    {

    }

    public void OnTriggerExit(Collider other)
    {
        GameManager.Instance.DialogManager.DialogEnd();
        hasDialogStarted = false;
    }
}
