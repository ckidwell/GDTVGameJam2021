using UnityEngine;

public class UIJewelry : MonoBehaviour
{
    public BoxCollider2D collider;
    public SpriteRenderer renderer;
    public Jewelry jewelry;
    private GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseUp()
    {
        collider.enabled = false;
        renderer.color = new Color(0, 0, 0, 0);
        gameController.LootItem(jewelry);
        
    }
}
