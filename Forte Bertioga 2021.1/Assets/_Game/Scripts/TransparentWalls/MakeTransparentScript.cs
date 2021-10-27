using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparentScript : MonoBehaviour
{
    [SerializeField] private List<Iam_InTheWay> currentlyInTheWay;
    [SerializeField] private List<Iam_InTheWay> alreadyTransparent;
    [SerializeField] private Transform player;
    private Transform camera;

    private void Awake()
    {
        currentlyInTheWay = new List<Iam_InTheWay>();
        alreadyTransparent = new List<Iam_InTheWay>();

        camera = this.gameObject.transform;
    }
    private void Update()
    {
        GetAllObjectsInTheWay();

        MakeObjectsSolid();
        MakeObjectsTransparent();

        
    }

    private void GetAllObjectsInTheWay()
    {
        currentlyInTheWay.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(camera.position - player.position);

        Ray ray1_Foward = new Ray(camera.position, player.position - camera.position);
        Ray ray1_Backward = new Ray(player.position, camera.position - player.position);

        var hits1_Foward = Physics.RaycastAll(ray1_Foward, cameraPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

        Debug.DrawRay(camera.position, player.position - camera.position, Color.green);

        foreach (var hit in hits1_Foward)
        {
            if (hit.collider.gameObject.TryGetComponent(out Iam_InTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }

        foreach (var hit in hits1_Backward)
        {
            if(hit.collider.gameObject.TryGetComponent(out Iam_InTheWay inTheWay))
            {
                if(!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }
    }
    
    private void MakeObjectsTransparent()
    {
        for (int i = 0; i < currentlyInTheWay.Count; i++)
        {
            Iam_InTheWay inTheWay = currentlyInTheWay[i];

            if(!alreadyTransparent.Contains(inTheWay))
            {
                inTheWay.ShowTransparent();
                alreadyTransparent.Add(inTheWay);
            }
        }
    }

    private void MakeObjectsSolid()
    {
        for (int i = alreadyTransparent.Count-1; i >= 0; i--)
        {
            Iam_InTheWay wasInTheWay = alreadyTransparent[i];

            if(!currentlyInTheWay.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                alreadyTransparent.Remove(wasInTheWay);
            }
        }
    }
}
