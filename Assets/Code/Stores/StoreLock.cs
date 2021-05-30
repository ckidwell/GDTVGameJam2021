using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreLock : MonoBehaviour
{
    public StoreName storeName;
    public delegate void PickDoor(StoreName name);
    public static event PickDoor OnPickDoor;

    private void OnMouseDown()
    {
        OnPickDoor(storeName);
        Debug.Log("You would have gone to a lock pick UI now for store: " + storeName);
    }
}
