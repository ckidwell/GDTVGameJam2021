using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptUnlock : MonoBehaviour
{
    public LockTypes thisLockType;
    public int caseNumber;
    private void OnMouseDown()
    {
        PickLock();
    }

    private void PickLock()
    {
        GameObject.Find("GameController").GetComponent<GameController>().PickLockForCase(thisLockType, caseNumber);
        //Debug.Log("I'm picking the lock now");
        //Lock pick code goes here
    } 
}
