using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerLeaveDoorButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private void OnMouseDown()
    {

        GameObject.Find("GameController").GetComponent<GameController>().LeaveDoorWay();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // dont give a rat butt but Unity forces me to implement this to see the OnPointerUpa
    }
}
