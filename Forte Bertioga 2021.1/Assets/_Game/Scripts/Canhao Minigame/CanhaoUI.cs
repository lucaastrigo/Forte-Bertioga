using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CanhaoUI : MonoBehaviour
{
    public float shootCooldown;
    //public float potenciaMin, potenciaMax;
    [Range(0, 100)] public float potenciaAtual;
    //[Range(0, 100)] public float sliderSpeed;

    public bool pressionado;

    public GameObject shootButton;
    public GameObject bullet;
    public Transform bocaCanhao;
    //public Slider slider;

    private float time;
    private bool canFire;
    private bool aumentando;

    void Start()
    {
        //potenciaAtual = potenciaMin;
        //slider.minValue = potenciaMin;
        //slider.maxValue = potenciaMax;
    }

    void Update()
    {
        //slider.value = potenciaAtual;

        if (time <= 0)
        {
            canFire = true;
        }
        else
        {
            time -= Time.deltaTime;
            canFire = false;
        }

        //if (pressionado)
        //{
        //    if(potenciaAtual < potenciaMax)
        //    {
        //        potenciaAtual += Time.deltaTime * sliderSpeed;
        //    }
        //}
        //else
        //{
        //    if(potenciaAtual > potenciaMin)
        //    {
        //        potenciaAtual -= Time.deltaTime * sliderSpeed;
        //    }
        //}
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
            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_tiro_alvejar_barril", transform.position);
            time = shootCooldown;

            //GameObject bo = Instantiate(bullet, bocaCanhao.position, bocaCanhao.rotation);
            //bo.GetComponent<BolaCanhao>().potencia = potenciaAtual;



            GameObject CreatedCannonball = Instantiate(bullet, bocaCanhao.position, bocaCanhao.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = bocaCanhao.transform.up * potenciaAtual;

        }
    }

}
