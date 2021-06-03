using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIJewelry : MonoBehaviour
{
    public BoxCollider2D collider;
    public Image image;
    public Jewelry jewelry;
    private GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        collider = GetComponent<BoxCollider2D>();
        image = GetComponent<Image>();
    }

    private void OnMouseUp()
    {
        collider.enabled = false;
        image.color = new Color(0, 0, 0, 0);
        gameController.LootItem(jewelry);
        
    }
}
