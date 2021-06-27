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
        print(agent.velocity.x + "X");
        print(agent.velocity.z + "Z");
        //print(agent.steeringTarget.x);

        if(Input.GetKeyDown(KeyCode.F))
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }

        if (agent.steeringTarget.z > transform.position.z && agent.steeringTarget.x < transform.position.x)
        {
            EsquerdaSprite();
            if (agent.steeringTarget.z > transform.position.z)
            {
                WalkUp();
            }
            if (agent.steeringTarget.x < transform.position.x)
            {
                WalkDown();
            }
        }
        else if (agent.steeringTarget.z < transform.position.z && agent.steeringTarget.x > transform.position.x)
        {
            DireitaSprite();
            if (agent.steeringTarget.z < transform.position.z)
            {
                WalkUp();
            }
            if (agent.steeringTarget.x > transform.position.x)
            {
                WalkDown();
            }
        }

        if (agent.steeringTarget.x > transform.position.x && agent.steeringTarget.z > transform.position.z)
        {
            WalkUp();
            if(agent.velocity.x > 3)
            {
                DireitaSprite();
            }
            else
            {
                EsquerdaSprite();
            }
        }
        else if (agent.steeringTarget.x < transform.position.x && agent.steeringTarget.z < transform.position.z)
        {
            WalkDown();
            if (agent.velocity.z < -3)
            {
                DireitaSprite();
            }
            else
            {
                EsquerdaSprite();
            }
        }




        if (agent.velocity == Vector3.zero)
        {
            anim.SetBool("walk", false);
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

    void WalkDown()
    {
        anim.SetBool("walk", true);
        anim.SetBool("walkUp", false);
    } 
    void WalkUp()
    {
        anim.SetBool("walkUp", true);
        anim.SetBool("walk", false);
    }
    void DireitaSprite()
    {
        sprite.flipX = true; //dir
    }
    void EsquerdaSprite()
    {
        sprite.flipX = false; //esq
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            cam.orthographicSize = 7.5f;
            zoom = true;

            if(other.GetComponent<Room>() != null)
            {
                other.other.GetComponent<Room>().EnterRoom();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            zoom = false;

            if (other.GetComponent<Room>() != null)
            {
                other.other.GetComponent<Room>().ExitRoom();
            }
        }
    }
}
