using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lock : MonoBehaviour
{
    public LockTypes locktype;

    public List<float> lockPositions;
    public List<Pin> pins;
    public bool locked = true;
    
    void Start()
    {
        lockPositions = new List<float>();
        var lockPinCount = GetPinsForType();
        lockPositions.Capacity = lockPinCount;
        for (var i = 0; i < lockPinCount; i++)
        {
            lockPositions.Add(Random.Range(.1f,.15f));
        }

        var o = 1;
        foreach (var pin in pins)
        {
            pin.order = o++;
        }
    }

    private void OnEnable()
    {
        Pin.OnPinSet += PinSet; 
    }

    private void OnDisable()
    {
        Pin.OnPinSet -= PinSet; 
    }

    private void PinSet(int whichPin)
    {
        foreach (var pin in pins)
        {
            if (pin.order == whichPin)
                pin.set = true;
        }

        if (CheckForUnlock())
        {
            Debug.Log("YOU UNLOCKED IT!");
        }
    }
    private bool CheckForUnlock()
    {
        return pins.All(pin => pin.set);
    }
    private int GetPinsForType()
    {
        return locktype switch
        {
            LockTypes.DOOR => 4,
            LockTypes.COPPER => 3,
            LockTypes.SILVER => 4,
            LockTypes.GOLD => 5,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
