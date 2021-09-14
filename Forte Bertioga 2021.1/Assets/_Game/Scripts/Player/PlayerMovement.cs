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
        //print(agent.velocity.z + "VELOCIDADE X");
        //print(agent.velocity.x + "VELOCIDADE X");

        if (Input.GetKeyDown(KeyCode.F))
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }

        //if (agent.velocity.x > 0.1f && agent.velocity.z < 0.1f)
        //{
        //    WalkUp();
        //    DireitaSprite();
        //}
        //else if (agent.velocity.x < -0.1f && agent.velocity.z < 0.1f)
        //{
        //    WalkDown();
        //    EsquerdaSprite();      
        //}  

        //if (agent.velocity.z > 0.1f && agent.velocity.x < 0.1f)
        //{
        //    WalkUp();
        //    EsquerdaSprite(); 
        //}
        //else if (agent.velocity.z < -0.1f && agent.velocity.x < 0.1f)
        //{
        //    DireitaSprite();
        //    WalkDown();
        //}



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
                    //hit.transform.gameObject.GetComponent<MiniGameAccess>().AccessMinigame();
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
            Room scriptRoom = other.GetComponent<Room>();

            if(scriptRoom != null)
            {
                //scriptRoom.EnterRoom();

                //if (scriptRoom.hasZoom)
                //{
                //    cam.orthographicSize = 7.5f;
                //    zoom = true;
                //}
            }
        }

        if (other.gameObject.CompareTag("Minigame"))
        {
            other.gameObject.GetComponent<MiniGameAccess>().AccessMinigame();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            Room scriptRoom = other.GetComponent<Room>();




            if (scriptRoom != null)
            {
                //scriptRoom.EnterRoom();

                //if (scriptRoom.hasZoom)
                //{
                //    cam.orthographicSize = 7.5f;
                //    zoom = true;
                //}
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            Room scriptRoom = other.GetComponent<Room>();

            if (scriptRoom != null)
            {
                //scriptRoom.ExitRoom();

                //if (scriptRoom.hasZoom)
                //{
                //    zoom = false;
                //}
            }
        }
    }
}
