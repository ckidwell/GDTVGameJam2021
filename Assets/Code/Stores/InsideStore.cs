using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideStore 
{
    public bool alarmTriggered = false;

    public JewelryBox[] boxes;
    // number JewelryBox
   
    // what lock type each case has?
    // what is in the case

    public InsideStore(int size)
    {
        boxes = new JewelryBox[size];

        for(int i = 0; i< size; i++)
        {
            boxes[i] = new JewelryBox();
        }

    }

}
