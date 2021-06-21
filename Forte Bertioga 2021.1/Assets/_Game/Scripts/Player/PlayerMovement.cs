using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator anim;
    public GameObject camera;

    NavMeshAgent agent;

    Vector3 mousePos;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
    }

    void Update()
    {
        if(agent.velocity.x != 0)
        {
            anim.SetBool("walk", true);

            if(agent.velocity.x > 0)
            {
                sprite.flipX = false;
            }
            else if(agent.velocity.x < 0)
            {
                sprite.flipX = true;
            }
        }
        else
        {
            anim.SetBool("walk", false);
        }

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

    // on trigger enter
    // if game obj that triggered player is a ROOM (tag)
    // camera zooms in

    // if player is not inside any room, camera zooms out

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            camera.GetComponent<Camera>().ortographicSize = 7.5f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            camera.GetComponent<Camera>().ortographicSize = 15;
        }
    }
}
