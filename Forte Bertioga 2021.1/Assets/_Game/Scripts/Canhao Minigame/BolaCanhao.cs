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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_tiro_alvejar_mar", transform.position);
        }

        if (other.gameObject.CompareTag("Barril"))
        {
            CanhaoGLOBAL.barrisCertos += 1;
            Destroy(other.gameObject);
            Destroy(gameObject);

            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_player_acertou_inimigo", transform.position);
        }
    }
}
