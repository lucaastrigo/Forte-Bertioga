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
        if (Input.GetKeyDown(KeyCode.F))
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }

        if(!zoom & cam.orthographicSize <= 15)
        {
            cam.orthographicSize += Time.deltaTime * speedCamera;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            Room scriptRoom = other.GetComponent<Room>();

            if(scriptRoom != null)
            {
                scriptRoom.EnterRoom();

                if (scriptRoom.hasZoom)
                {
                    cam.orthographicSize = 7.5f;
                    zoom = true;
                }
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
                scriptRoom.EnterRoom();

                if (scriptRoom.hasZoom)
                {
                    cam.orthographicSize = 7.5f;
                    zoom = true;
                }
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
                scriptRoom.ExitRoom();

                if (scriptRoom.hasZoom)
                {
                    zoom = false;
                }
            }
        }
    }
}
