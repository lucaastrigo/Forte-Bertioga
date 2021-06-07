using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCanhao : MonoBehaviour
{
    public float speedModifier;
    [HideInInspector] public float potencia;

    void Start()
    {
        //
    }

    void Update()
    {
        transform.Translate(Vector3.forward * potencia * speedModifier);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Barril>() != null)
        {
            if (other.gameObject.GetComponent<Barril>().barrilCerto)
            {
                CanhaoGLOBAL.barrisCertos++;
            }
            else
            {
                CanhaoGLOBAL.barrisErrados++;
            }
        }
    }
}
