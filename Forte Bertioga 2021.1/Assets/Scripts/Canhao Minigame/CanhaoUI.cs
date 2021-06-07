using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanhaoUI : MonoBehaviour
{
    public float shootCooldown;
    public float potenciaMin, potenciaMax;
    public GameObject shootButton;
    public GameObject bullet;
    public Transform bocaCanhao;
    public Slider slider;

    private float time;
    private float potenciaAtual;
    private bool canFire;
    private bool aumentando;

    private void Update()
    {
        slider.value = potenciaAtual;

        if (time <= 0)
        {
            canFire = true;
        }
        else
        {
            time -= Time.deltaTime;
            canFire = false;
        }

        if (potenciaAtual <= potenciaMin)
        {
            aumentando = true;
        }
        else if(potenciaAtual >= potenciaMax)
        {
            aumentando = false;
        }

        if (aumentando)
        {
            potenciaAtual += Time.deltaTime;
        }
        else
        {
            potenciaAtual -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (canFire)
        {
            time = shootCooldown;
            bullet.GetComponent<BolaCanhao>().potencia = potenciaAtual;
            Instantiate(bullet, bocaCanhao.position, bocaCanhao.rotation);
            print(potenciaAtual);
        }
    }
}
