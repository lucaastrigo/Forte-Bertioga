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
}
