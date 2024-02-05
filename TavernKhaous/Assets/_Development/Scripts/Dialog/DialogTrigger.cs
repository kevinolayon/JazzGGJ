using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool hasDialogStarted = false;

    [SerializeField]
    private int _dialogRoot;

    [SerializeField]
    private SOClient client;

    [SerializeField]
    private KeyCode _dialogKey;

    public void OnTriggerEnter(Collider other)
    {
       
    }

    public void OnTriggerStay(Collider other)
    { 
        if (_dialogRoot != -1)
        {
            if (!hasDialogStarted && Input.GetKeyDown(_dialogKey))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Trigger Player");
                    hasDialogStarted = true;
                    GameManager.Instance.DialogManager.StartDialog(_dialogRoot);
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
