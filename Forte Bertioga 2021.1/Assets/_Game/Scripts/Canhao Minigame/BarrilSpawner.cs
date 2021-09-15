using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilSpawner : MonoBehaviour
{
    public float spawnCooldown;
    public bool vaiPraEsquerda;
    public GameObject barril;

    private float time;

    void Update()
    {
        if(time <= 0)
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
        GameObject b = Instantiate(barril, transform.position, Quaternion.identity);
        b.GetComponent<Barril>().vaiPraEsquerda = vaiPraEsquerda;

        if(Barril.horizontalSpeed > 0)
        {
            Barril.horizontalSpeed = CanhaoGLOBAL.barrisCertos / 3;
        }
        else
        {
            Barril.horizontalSpeed = 1;
        }

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
