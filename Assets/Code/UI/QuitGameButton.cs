using UnityEngine;
using UnityEngine.EventSystems;

public class QuitGameButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    void Start()
    {
       #if !UNITY_STANDALONE
       Destroy(gameObject);
        #endif
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        Application.Quit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // dont give a rat butt but Unity forces me to implement this to see the OnPointerUp
    }
}
