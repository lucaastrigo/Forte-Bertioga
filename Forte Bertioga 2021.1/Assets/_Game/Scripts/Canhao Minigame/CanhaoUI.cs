using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CanhaoUI : MonoBehaviour
{
    public float shootCooldown;
    public float potenciaMin, potenciaMax;
    [Range(0, 1)] public float sliderSpeed;
    
    public bool pressionado;

    public GameObject shootButton;
    public GameObject bullet;
    public Transform bocaCanhao;
    public Slider slider;

    private float time;
    private float potenciaAtual;
    private bool canFire;
    private bool aumentando;

    void Start()
    {
        potenciaAtual = potenciaMin;
        slider.minValue = potenciaMin;
        slider.maxValue = potenciaMax;
    }

    void Update()
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

        /*if (potenciaAtual <= potenciaMin)
        {
            aumentando = true;
        }
        else if(potenciaAtual >= potenciaMax)
        {
            aumentando = false;
        }

        if (aumentando)
        {
            potenciaAtual += Time.deltaTime * sliderSpeed;
        }
        else
        {
            potenciaAtual -= Time.deltaTime * sliderSpeed;
        }*/

        if (pressionado)
        {
            if(potenciaAtual < potenciaMax)
            {
                potenciaAtual += Time.deltaTime * sliderSpeed;
            }
        }
        else
        {
            if(potenciaAtual > potenciaMin)
            {
                potenciaAtual -= Time.deltaTime * sliderSpeed;
            }
        }
    }

    public void Pressiona()
    {
        pressionado = true;
    }

    public void Solta()
    {
        pressionado = false;

        Shoot();
    }

    public void Shoot()
    {
        if (canFire)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/canhao/sfx_canhao_tiro", transform.position);
            time = shootCooldown;
            GameObject bo = Instantiate(bullet, bocaCanhao.position, bocaCanhao.rotation);
            bo.GetComponent<BolaCanhao>().potencia = potenciaAtual;
        }
    }
}
