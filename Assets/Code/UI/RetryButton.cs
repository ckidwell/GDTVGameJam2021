using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RetryButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private MenuController _menuController;
    void Start()
    {
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _menuController.PlayGame();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // dont give a rat butt but Unity forces me to implement this to see the OnPointerUp
    }
}
