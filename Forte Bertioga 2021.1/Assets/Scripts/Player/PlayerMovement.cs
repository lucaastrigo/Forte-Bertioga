using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

    Vector3 mousePos;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();

    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            //mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
           
            //transform.position = mousePos;

            Ray ponto = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ponto, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Chao") agent.SetDestination(hit.point);

                //transform.position = hit.point

                if (hit.transform.gameObject.GetComponent<MiniGameAccess>() != null)
                {
                    hit.transform.gameObject.GetComponent<MiniGameAccess>().AccessMinigame();
                }
               
            }
        }
    }
}
