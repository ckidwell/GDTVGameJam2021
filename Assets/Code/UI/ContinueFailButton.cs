using UnityEngine;
using UnityEngine.EventSystems;

public class ContinueFailButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("MenuController").GetComponent<MenuController>().GameOver();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // dont give a rat butt but Unity forces me to implement this to see the OnPointerUpa
    }
}
