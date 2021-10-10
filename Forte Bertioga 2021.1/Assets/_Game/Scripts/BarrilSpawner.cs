using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilSpawner : MonoBehaviour
{
    public float spawnCooldown;
    public float force;
    //public bool vaiPraEsquerda;
    public GameObject barril;

    private float time;

    void Update()
    {
        if (time <= 0)
        {
            Spawn();
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    void Spawn()
    {

        GameObject b = Instantiate(barril, transform.position, transform.rotation);
        b.GetComponent<Rigidbody>().velocity = transform.right * force;

        if (Random.Range(0, 100) <= 70)
        {
            b.GetComponent<Barril>().barrilCerto = true;
        }
        else
        {
            b.GetComponent<Barril>().barrilCerto = false;
        }

        time = spawnCooldown;
    }
}
