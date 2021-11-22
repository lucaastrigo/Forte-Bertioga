using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DialogBox : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public bool clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = true;
    }
}
