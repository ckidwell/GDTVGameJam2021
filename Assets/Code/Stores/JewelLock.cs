using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelLock : MonoBehaviour
{
    public StoreName storeName;
    public LockTypes lockType;
    public int caseNumber;
    public delegate void PickBox(StoreName name, LockTypes lockType, int lockNumber);
    public static event PickBox OnPickBox;

    private void OnMouseDown()
    {
        OnPickBox(storeName,lockType,caseNumber);
        Debug.Log("You would have gone to a lock pick UI now for store: " + storeName);
    }
}