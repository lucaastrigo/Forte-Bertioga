using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float originalY, finalY;
    public GameObject[] target;

    public void EnterRoom()
    {
        for (int i = 0; i < target.Length; i++)
        {
            Vector3 pos = target[i].transform.position;
            pos.y = finalY;
            target[i].transform.position = pos;
        }
    }

    public void ExitRoom()
    {
        for (int i = 0; i < target.Length; i++)
        {
            Vector3 pos = target[i].transform.position;
            pos.y = originalY;
            target[i].transform.position = pos;
        }
    }
}
