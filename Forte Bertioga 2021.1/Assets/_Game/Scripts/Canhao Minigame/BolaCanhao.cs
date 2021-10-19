using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCanhao : MonoBehaviour
{

    public GameObject waterVFX;
    public GameObject explosion;
    private int hitpoints = 1;
    Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, 2f);


    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_tiro_alvejar_mar", transform.position);
            Instantiate(waterVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        if (other.gameObject.CompareTag("Barril"))
        {
            hitpoints--;
            if (hitpoints > -1)
            {
                CanhaoGLOBAL.barrisCertos += 1;
            }
            Instantiate(explosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_tiro_alvejar_barril", transform.position);
        }
    }
}
