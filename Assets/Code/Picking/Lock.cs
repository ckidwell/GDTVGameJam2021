using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lock : MonoBehaviour
{
    private SoundController soundController;
    public LockTypes locktype;

    public List<float> lockPositions;
    public List<Pin> pins;
    public bool locked = true;
    
    public delegate void SendLockPickMessage(string message);
    public static event SendLockPickMessage OnSendLockPickMessage;
    
    void Start()
    {
        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
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
            pin.lockHeight = Random.Range(.1f, .15f);
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
        var resetPins = false;
        foreach (var pin in pins)
        {
            if (pin.order < whichPin && !pin.set)
            {
                resetPins = true;
                break;
            }
            if (pin.order == whichPin)
                pin.set = true;
        }
        if(resetPins)
            ResetPins();
        
        if (CheckForUnlock())
        {
            OnSendLockPickMessage("YOU UNLOCKED IT!");
            soundController.PlayLockOpen1();
            return;
        }  
        soundController.PlayLockClick1();
        OnSendLockPickMessage("PIN SET");
    }

    private void ResetPins()
    {
        soundController.PlayPinReset();
        OnSendLockPickMessage("WRONG ORDER - LOCK RESET");
        foreach (var pin in pins)
        {
            pin.SetPin(false);
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
