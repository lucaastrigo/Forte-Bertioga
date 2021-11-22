using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Interativo : MonoBehaviour
{
    public DialogoObejto textoDialogo;
    public GameObject dialogoUI;

    bool ativo;

    void Start()
    {
        //
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Ray ray2 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray2, out hit))
            {
                if (hit.collider.tag == "Interativo" && !ativo)
                {
                    dialogoUI.GetComponent<DialogoUI>().MostrarDialogo(textoDialogo);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            dialogoUI.GetComponent<DialogoUI>().MostrarDialogo(textoDialogo);
        }
    }
}
