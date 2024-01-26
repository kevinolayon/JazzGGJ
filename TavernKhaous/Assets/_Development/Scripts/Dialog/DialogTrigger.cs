using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private SODialog dialog;
    private bool hasDialogStarted = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasDialogStarted)
        {
            hasDialogStarted = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {

    }

    public void OnTriggerExit(Collider other)
    {
        hasDialogStarted = false;
    }
}
