using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanhaoGLOBAL : MonoBehaviour
{
    public static int barrisCertos, barrisErrados;

    public TextMeshProUGUI acertos;
    public TextMeshProUGUI erros;

    private void Update()
    {
        acertos.text = "Acertos: " + barrisCertos;
        erros.text = "Erros: " + barrisErrados;
    }
}
