using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideStore 
{
    public bool alarmTriggered = false;
    public bool locked = true;
    public bool visited = false;
    public StoreName name;
    public JewelryBox[] boxes;
    public InsideStore(int size, StoreName name)
    {
        boxes = new JewelryBox[size];
        this.name = name;

        for (int i = 0; i < size; i++)
        {
            boxes[i] = new JewelryBox(JewelryBox.GetRandomJewelryBoxSize());
        }
    }
}
