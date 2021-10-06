using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public float limit;

    private bool holding;

    Collider coll;

    Vector3 posicao;
    Ray ponto;
    RaycastHit hit;
    void Start()
    {
        coll = GetComponentInChildren<Collider>();
    }

    void Update()
    {
        print(transform.localEulerAngles.y);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!holding)
            {
                ponto = Camera.main.ScreenPointToRay(Input.mousePosition);
            }

            if (Physics.Raycast(ponto, out hit, Mathf.Infinity))
            {

                if (touch.phase == TouchPhase.Began)
                {
                    posicao = new Vector3(touch.position.x, 0, 0);

                    if (hit.transform == transform.GetChild(0))
                    {
                        print("aa");
                        holding = true;

                    }
                    
                }
                
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (holding)
                {
                    Vector3 newPosicao = new Vector3(touch.position.x, 0, 0);

                    if (newPosicao.x < posicao.x )
                    {
                        //print("esquerda");

                        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_canhao_mov", transform.position);

                        float rotationSpeed = 1;
                        float xAxis = -rotationSpeed;
                        
                        transform.Rotate(Vector3.up, xAxis, Space.World);

                    }
                    else if (newPosicao.x > posicao.x)
                    {
                        //print("direita");

                        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_canhao_mov", transform.position);

                        float rotationSpeed = 1;
                        float xAxis = rotationSpeed;
                        transform.Rotate(Vector3.up, xAxis, Space.World);

                    }

                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                holding = false;
            }
        }
    }
}
