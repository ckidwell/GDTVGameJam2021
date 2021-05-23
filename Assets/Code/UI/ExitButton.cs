using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("GameController").GetComponent<GameController>().ExitToMain();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // dont give a rat butt but Unity forces me to implement this to see the OnPointerUp
    }
}
