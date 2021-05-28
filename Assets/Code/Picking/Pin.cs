using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector2 startingPosition;
    private float yHeightLimit = .15f;
    public bool set = false;
    public int order = 0;
    public float lockHeight;
    
    public delegate void PinSet(int order);
    public static event PinSet OnPinSet;
    void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        var t = transform;
        if (set)
        {
            t.position = new Vector2(t.position.x, lockHeight);
            return;
        }

        if(t.position.y >= lockHeight -.01 && t.position.y <= lockHeight +.01)
        {
            set = true;
            Debug.Log("I just set a pin of order" + order);
            OnPinSet(order);
            return;
        }

        if (t.position.y < startingPosition.y)
            t.position = new Vector3(startingPosition.x, startingPosition.y);

        if (t.position.y > yHeightLimit)
        {
            t.position = new Vector3(t.position.x, yHeightLimit);
        }
    }

    public void SetPin(bool set)
    {
        this.set = set;

        if (set)
        {

            return;
        }
        
    }
    
}
