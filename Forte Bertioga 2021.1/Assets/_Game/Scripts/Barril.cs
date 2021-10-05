using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    //[HideInInspector] public static float horizontalSpeed = 1;
    //[HideInInspector] public bool vaiPraEsquerda;
    [HideInInspector] public bool barrilCerto;

    //public float speedModifier;

    Material m;

    void Start()
    {
        m = GetComponent<Renderer>().material;
        Destroy(gameObject, 50f);
    }

    void Update()
    {
        if (barrilCerto)
        {
            m.color = Color.red;

        }
        else
        {
            m.color = Color.green;

        }

        //if (vaiPraEsquerda)
        //{
        //    transform.Translate(Vector3.left * horizontalSpeed / 20 * Time.timeScale * speedModifier);
        //}
        //else
        //{
        //    transform.Translate(Vector3.right * horizontalSpeed / 20 * Time.timeScale * speedModifier);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
