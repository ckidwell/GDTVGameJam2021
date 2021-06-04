using UnityEngine;

public class StoreLock : MonoBehaviour
{
    public StoreName storeName;
    public delegate void PickDoor(StoreName name);
    public static event PickDoor OnPickDoor;

    private void OnMouseDown()
    {
        OnPickDoor(storeName);
    }
}
