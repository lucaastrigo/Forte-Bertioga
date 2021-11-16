using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Interativo : MonoBehaviour
{
<<<<<<< Updated upstream
    public DialogoObejto textoDialogo;
    public GameObject dialogoUI;
=======
    public string textinho;
    public TextMeshProUGUI tmp;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
                    dialogoUI.GetComponent<DialogoUI>().MostrarDialogo(textoDialogo);
                }
            }
        }
    }
=======
                    StartCoroutine(Dialogue());
                }
            }

            if (ativo)
            {
                tmp.gameObject.SetActive(false);
                ativo = false;
            }
        }
    }

    IEnumerator Dialogue()
    {
        tmp.gameObject.SetActive(true);
        tmp.text = textinho;

        yield return new WaitForSeconds(0.25f);

        ativo = true;
    }
>>>>>>> Stashed changes
}
