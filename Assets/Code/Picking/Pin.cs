using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector2 startingPosition;
    private float yHeightLimit = .15f;
    void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        var t = transform;
        if (t.position.y < startingPosition.y)
            t.position = new Vector3(startingPosition.x, startingPosition.y);

        if (transform.position.y > yHeightLimit)
        {
            t.position = new Vector3(t.position.x, yHeightLimit);
        }
    }
}
