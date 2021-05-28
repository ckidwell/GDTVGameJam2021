using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptUnlock : MonoBehaviour
{
    private void OnMouseDown()
    {
        PickLock();
    }

    private void PickLock()
    {
        Debug.Log("I'm picking the lock now");
        //Lock pick code goes here
    } 
}
