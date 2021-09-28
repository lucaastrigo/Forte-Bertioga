using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CannonButton : MonoBehaviour
{
    public GameObject pivotCanhao;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(Pressionado);
    }

    void Pressionado()
    {
        //pivotCanhao.GetComponent<CanhaoUI>().pressionado = true;
    }
}
