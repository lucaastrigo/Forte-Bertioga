using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CanhaoGLOBAL : MonoBehaviour
{
    public int quantAcertos;
    public static int barrisCertos, barrisErrados;

    public TextMeshProUGUI acertos;
    public GameObject telaVitoria;
    //public TextMeshProUGUI erros;

    private void Update()
    {
        acertos.text = barrisCertos + "/" + quantAcertos;
        //erros.text = "Erros: " + barrisErrados;

        if(barrisCertos >= quantAcertos)
        {
            telaVitoria.SetActive(true);
            barrisCertos = 0;
        }
    }
}
