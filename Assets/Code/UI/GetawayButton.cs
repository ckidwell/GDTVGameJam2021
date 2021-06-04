using UnityEngine;
using UnityEngine.EventSystems;
public class GetawayButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // dont give a rat butt but Unity forces me to implement this to see the OnPointerUpa
    }
}
