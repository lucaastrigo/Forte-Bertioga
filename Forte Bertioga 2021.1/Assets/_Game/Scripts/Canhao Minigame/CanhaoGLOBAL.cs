using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CanhaoGLOBAL : MonoBehaviour
{
    public static int barrisCertos, barrisErrados;

    public TextMeshProUGUI acertos;
    //public TextMeshProUGUI erros;

    private void Update()
    {
        acertos.text = barrisCertos + "/18";
        //erros.text = "Erros: " + barrisErrados;

        if(barrisCertos >= 18)
        {
            SceneManager.LoadScene("MovementPrototype");
        }
    }
}
