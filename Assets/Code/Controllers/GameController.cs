using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private MenuController _menuController;
    private CameraController cameraController;
    public GameObject goldLock;
    public GameObject silverLock;
    public GameObject copperLock;
    public GameObject doorLock;
   
    //scene game objects to organize in game activities
    public GameObject lockPickingGO;
    public GameObject jewelryStoreGO;
    public GameObject citySceneGO;
    public GameObject storesGO;
    
    // variables to store state of what store we are attempting
    private GameObject currentlock;
    private StoreName currentStoreName;
    
    void Start()
    {
        cameraController = GameObject.Find("Camera Controller").GetComponent<CameraController>();
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        cameraController.SetActiveCamera(CameraActive.OUTSIDE);
        SetActivity(ActivityType.CITY);
        // SpawnLockOfType(LockTypes.GOLD);
    }
    
    private void OnEnable()
    {
        StoreLock.OnPickDoor += PickDoor; 
    }

    private void OnDisable()
    {
        StoreLock.OnPickDoor -= PickDoor; 
    }

    public void PickDoor(StoreName name)
    {
        currentStoreName = name;
        SpawnLockOfType(LockTypes.DOOR);
        SetActivity(ActivityType.LOCKPICKING);
    }
    public void SetActivity(ActivityType type)
    {
        storesGO.SetActive(false);
        lockPickingGO.SetActive(false);
        jewelryStoreGO.SetActive(false);
        citySceneGO.SetActive(false);
        switch (type)
        {
            case ActivityType.CITY:
                cameraController.SetActiveCamera(CameraActive.OUTSIDE);
                storesGO.SetActive(true);
                citySceneGO.SetActive(true);
                break;
            case ActivityType.STORE:
                cameraController.SetActiveCamera(CameraActive.INSIDE);
                jewelryStoreGO.SetActive(true);
                break;
            case ActivityType.LOCKPICKING:
                cameraController.SetActiveCamera(CameraActive.LOCKPICK);
                lockPickingGO.SetActive(true);
                break;
            case ActivityType.WIN:
                break;
            case ActivityType.LOSS:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "somehow you managed to pass in an invalid activity type");
        }
    }
    public void SpawnLockOfType(LockTypes type)
    {
        var spawnPosition = new Vector3(-55, 0, 0);
        switch (type)
        {
            case LockTypes.DOOR:
                currentlock = Instantiate(doorLock,spawnPosition,Quaternion.identity);
                break;
            case LockTypes.COPPER:
                currentlock = Instantiate(copperLock,spawnPosition,Quaternion.identity);
                break;
            case LockTypes.SILVER:
                currentlock = Instantiate(silverLock,spawnPosition,Quaternion.identity);
                break;
            case LockTypes.GOLD:
                currentlock = Instantiate(goldLock,spawnPosition,Quaternion.identity);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "Somehow you told me to spawn a lock type that does not exist");
        }
    }
    
    public void StartNewGame()
    {
        // do whatever is needed to setup a new game sequence
    }

    public void GameOver()
    {
        // do what is needed to summarize the end game results 
    }

    public void ExitToMain()
    {
        // do what is needed to return to the main menu
    }
}
