using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    private void Start()
    {
        FindObjectOfType<DialogManager>().DialogStart(dialog);
    }
}
