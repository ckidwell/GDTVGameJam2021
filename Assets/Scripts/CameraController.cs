using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject outsideCam;
    [SerializeField] GameObject insideCam;
    [SerializeField] GameObject lockPickingCam;
    [SerializeField] float movementSpeed = 5.0f;

    //Serialized for testing
    [SerializeField] bool playerInsideStore = false;
    
    void Start()
    {
        outsideCam.SetActive(true);
        insideCam.SetActive(false);
        lockPickingCam.SetActive(false);
    }

    public void SetActiveCamera(CameraActive camToSetActive)
    {
        outsideCam.SetActive(false);
        insideCam.SetActive(false);
        lockPickingCam.SetActive(false);
        switch (camToSetActive)
        {
            case CameraActive.OUTSIDE:
                outsideCam.SetActive(true);
                break;
            case CameraActive.INSIDE:
                insideCam.SetActive(true);
                break;
            case CameraActive.LOCKPICK:
                lockPickingCam.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(camToSetActive), camToSetActive, "Invalid camera to set active.");
        }
    }
    //Meant to be called once the player is successfully in the store
    public void doorIsOpen()
    {
        playerInsideStore = true;
    }
}

public enum CameraActive
{
    OUTSIDE,
    INSIDE,
    LOCKPICK
}