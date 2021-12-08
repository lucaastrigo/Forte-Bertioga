using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Interativo : MonoBehaviour
{
    public DialogoObejto textoDialogo;
    public DialogoCutscene textoCutscene;
    public GameObject dialogoUI;
    public TextMeshProUGUI playerName;

    [HideInInspector] public string nomeJigador;
    [HideInInspector]public bool ativo;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Ray ray2 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray2, out hit))
            {
                if (hit.collider.tag == "Interativo"&& dialogoUI.GetComponent<DialogoUI>().caixaDialogo.activeSelf == false)
                {
                    dialogoUI.GetComponent<DialogoUI>().MostrarDialogo(textoDialogo);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && dialogoUI.GetComponent<DialogoUI>().caixaDialogo.activeSelf == false)
        {
            print("tomei no cu");
            dialogoUI.GetComponent<DialogoUI>().MostrarDialogo(textoDialogo);
        }
    }

    public void ComecaDialogo()
    {
        dialogoUI.GetComponent<DialogoUI>().MostrarDialogoCutscene(textoCutscene, nomeJigador);
    }

    public void SalvaNome()
    {
        nomeJigador = playerName.text;
    }
}
