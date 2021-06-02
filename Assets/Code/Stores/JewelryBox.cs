using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class JewelryBox 
{
    public JewelryBoxSizes size;
    public bool isOpen;
    private List<Jewelry> itemsInside;

    public GameObject[] jewelrySpots;
    private int itemsInSmall = 3;
    private int itemsInLarge = 5;

    public JewelryBox(JewelryBoxSizes size)
    {
        this.size = size; // GetRandomJewelryBoxSize();
        isOpen = false;
        FillRandomItems(size == JewelryBoxSizes.SMALL ? itemsInSmall : itemsInLarge);
    }

    private void FillRandomItems(int numItems)
    {
        itemsInside = new List<Jewelry>();
        for (int i = 0; i < numItems; i++)
        {
          
            itemsInside.Add(new Jewelry());
        }
    }
    public static JewelryBoxSizes GetRandomJewelryBoxSize()
    {
        return UnityEngine.Random.Range(1, 100) < 50 ? JewelryBoxSizes.SMALL : JewelryBoxSizes.LARGE;
    }
    
}
public enum JewelryBoxSizes
{
    SMALL,
    LARGE
}

