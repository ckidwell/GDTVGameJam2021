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

    public InsideStore()
    {
        boxes = new[]
        {
            new JewelryBox() {size = JewelryBox.GetRandomJewelryBoxSize(), isOpen = false},
            new JewelryBox() {size = JewelryBox.GetRandomJewelryBoxSize(), isOpen = false},
            new JewelryBox() {size = JewelryBox.GetRandomJewelryBoxSize(), isOpen = false},
            new JewelryBox() {size = JewelryBox.GetRandomJewelryBoxSize(), isOpen = false},
            new JewelryBox() {size = JewelryBox.GetRandomJewelryBoxSize(), isOpen = false},
        };
    }

}
