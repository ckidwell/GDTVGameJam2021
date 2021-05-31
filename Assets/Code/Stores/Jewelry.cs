using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Jewelry 
{
    public JewelryTypes jewelryType;

    public Jewelry()
    {
        jewelryType = GetRandomType();
    }
    public JewelryTypes GetRandomType()
    {
        Array values = Enum.GetValues(typeof(JewelryTypes));
        return(JewelryTypes)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        
    }
}

public enum JewelryTypes
{
    GOLDRING,
    COPPERRING,
    SILVERRING,
    GOLDCOIN,
    DIAMOND,
    RUBY,
    EMERALD,
    SAPPHIRE,
    AMETHYST,
    PENDANT
    
}