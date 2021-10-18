using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    //[HideInInspector] public static float horizontalSpeed = 1;
    //[HideInInspector] public bool vaiPraEsquerda;
    [HideInInspector] public bool barrilCerto;
    public GameObject barrilExplosivo;
    public GameObject barrilNormal;

    //public float speedModifier;

    Material m;

    void Start()
    {
        m = GetComponentInChildren<Renderer>().material;
        //Destroy(gameObject, 30f);
    }

    void Update()
    {
        if (barrilCerto)
        {
            barrilExplosivo.SetActive(true);
            barrilNormal.SetActive(false);
        }
        else
        {
            barrilNormal.SetActive(true);
            barrilExplosivo.SetActive(false);

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
