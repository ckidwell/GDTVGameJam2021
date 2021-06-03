using UnityEngine;

public class UIJewelry : MonoBehaviour
{
    public BoxCollider2D collider;
    public Jewelry jewelry;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseUp()
    {
        Debug.Log("Someone tried to loot me!" ); //+ jewelry.jewelryType
    }
}
