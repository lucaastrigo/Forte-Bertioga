using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCanhao : MonoBehaviour
{
    //public float speedModifier;
    //[HideInInspector] public float potencia;

    Rigidbody rb;

    void Start()
    {
        //Destroy(gameObject, 5f);
        //rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * 1.7f * potencia, ForceMode.Impulse);
        //rb.AddForce(transform.up * potencia / 4.3f, ForceMode.Impulse);

    }

    void Update()
    {
        //transform.Translate(Vector3.forward * potencia * speedModifier);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Barril>() != null)
        {
            if (other.gameObject.GetComponent<Barril>().barrilCerto)
            {
                CanhaoGLOBAL.barrisCertos++;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if (!other.gameObject.GetComponent<Barril>().barrilCerto)
            {
                CanhaoGLOBAL.barrisErrados++;
                Destroy(other.gameObject);
                Destroy(gameObject);

            }
        }
    }
}
