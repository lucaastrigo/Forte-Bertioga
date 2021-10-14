using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public float limit;

    private bool holding;
    public VariableJoystick variableJoystick;

    Collider coll;

    Vector3 posicao;
    Ray ponto;
    RaycastHit hit;
    void Start()
    {
        coll = GetComponentInChildren<Collider>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (Vector3.forward + Vector3.right) * variableJoystick.Vertical + (Vector3.right + Vector3.back) * variableJoystick.Horizontal;

        if (direction.x < 0 && transform.eulerAngles.y > 120)
        {
            //print("esquerda");

            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_canhao_mov", transform.position);

            float rotationSpeed = 15f;
            float xAxis = -rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, xAxis, Space.World);
        }
        else if (direction.x > 0 && transform.eulerAngles.y < 180)
        {
            //print("direita");

            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/canhao/sfx_canhao_mov", transform.position);

            float rotationSpeed = 15f;
            float xAxis = rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, xAxis, Space.World);
        }





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

            if (touch.phase == TouchPhase.Ended)
            {
                holding = false;
            }
        }
    }
}
