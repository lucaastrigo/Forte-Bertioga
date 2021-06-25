using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public float speedCamera;
    public SpriteRenderer sprite;
    public Animator anim;
    public GameObject camera;

    private bool zoom;

    NavMeshAgent agent;
    Camera cam;

    Vector3 mousePos;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        cam = camera.GetComponent<Camera>();
    }

    void Update()
    {
        if (agent.steeringTarget.x > transform.localPosition.x)
        {
            anim.SetBool("walk", false);
            anim.SetBool("walkUp", true);
        }
        else if (agent.steeringTarget.x < transform.localPosition.x)
        {
            anim.SetBool("walk", true);
            anim.SetBool("walkUp", false);
        }

        
        if (agent.steeringTarget.z > transform.position.z)
        {
            //sprite.flipX = false; //esq
        }
        else if (agent.steeringTarget.z < transform.position.z)
        {
            //sprite.flipX = true; //dir
        }
        

        if (agent.velocity.z != 0)
        {
            /*
            if(agent.velocity.z > 0)
            {
                sprite.flipX = false;
            }
            else if(agent.velocity.z < 0)
            {
                sprite.flipX = true;
            }*/
        }
        else
        {
            anim.SetBool("walk", false); //walk down
            anim.SetBool("walkUp", false);
        }

        if (Input.GetMouseButtonDown(0))
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

        //if(zoom & cam.orthographicSize >= 7.5f)
        //{
        //    cam.orthographicSize -= Time.deltaTime * speedCamera;
        //} 
        if(!zoom & cam.orthographicSize <= 15)
        {
            cam.orthographicSize += Time.deltaTime * speedCamera;
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
            cam.orthographicSize = 7.5f;
            zoom = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            zoom = false;
        }
    }
}
