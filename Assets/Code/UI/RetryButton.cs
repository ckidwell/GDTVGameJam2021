using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RetryButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("GameController").GetComponent<GameController>().StartNewGame();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // dont give a rat butt but Unity forces me to implement this to see the OnPointerUp
    }
}
