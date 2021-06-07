using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    [HideInInspector] public static float horizontalSpeed = 1;
    [HideInInspector] public bool vaiPraEsquerda;
    [HideInInspector] public bool barrilCerto;

    Material m;

    void Start()
    {
        m = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (barrilCerto)
        {
            m.color = Color.cyan;
        }
        else
        {
            m.color = Color.red;
        }

        if (vaiPraEsquerda)
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
        }
    }
}
