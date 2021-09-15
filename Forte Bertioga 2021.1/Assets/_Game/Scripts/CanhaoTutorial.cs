using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoTutorial : MonoBehaviour
{
    public float timeToShow;

    void Start()
    {
        Destroy(gameObject, timeToShow);
    }
}
