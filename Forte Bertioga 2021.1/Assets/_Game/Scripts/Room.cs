using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [HideInInspector] private float originalY, finalY;

    public GameObject[] target;

    public bool hasZoom;
    public float desceValue;

    private float _originalY, _finalY;
    private float speedAnimation = 2;
    private bool isAnim;
    private bool animated = true;

    private void Start()
    {
        originalY = transform.position.y;
        finalY = transform.position.y - desceValue;

        _originalY = originalY;
        _finalY = finalY;

        /*
        for (int i = 0; i < target.Length; i++)
        {
            Vector3 pos = target[i].transform.position;
            pos.y = originalY;
            target[i].transform.position = pos;
        }
        */
    }

    private void Update()
    {
        if (!animated)
        {
            if (isAnim)
            {
                if (_originalY >= _finalY)
                {

                    _originalY -= Time.deltaTime * speedAnimation;

                    for (int i = 0; i < target.Length; i++)
                    {
                        Vector3 pos = target[i].transform.position;
                        pos.y = _originalY;
                        target[i].transform.position = pos;
                    }
                }

            }
            else
            {
                if (_originalY <= originalY)
                {
                    _originalY += Time.deltaTime * speedAnimation;

                    for (int i = 0; i < target.Length; i++)
                    {
                        Vector3 pos = target[i].transform.position;
                        pos.y = _originalY;
                        target[i].transform.position = pos;
                    }
                }
                else
                {
                    _originalY = originalY;
                    animated = true;
                }

            }
        }



    }

    public void EnterRoom()
    {
        isAnim = true;
        animated = false;
    }

    public void ExitRoom()
    {
        isAnim = false;
    }
}
