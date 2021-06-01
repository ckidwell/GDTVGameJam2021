using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

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
    
    //store table prefabs
    public GameObject smallJewelryTable;
    public GameObject largeJewelryTable;
    public GameObject table1Anchor;
    public GameObject table2Anchor;
    public GameObject table3Anchor;
    public GameObject table4Anchor;
    public GameObject table5Anchor;
    
    // variables to store state of what store we are attempting
    private Stores allStores;
    private GameObject currentlock;
    private StoreName currentStoreName;
    
    void Start()
    {
        cameraController = GameObject.Find("Camera Controller").GetComponent<CameraController>();
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        cameraController.SetActiveCamera(CameraActive.OUTSIDE);
        StartNewGame();
        SetActivity(ActivityType.CITY);

    }
    
    private void OnEnable()
    {
        StoreLock.OnPickDoor += PickDoor; 
    }

    private void OnDisable()
    {
        StoreLock.OnPickDoor -= PickDoor; 
    }

    public void AlarmTriggeredForCurrentStore()
    {
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (myStore != null) myStore.alarmTriggered = true;
    }
    public void PickDoor(StoreName name)
    {
        currentStoreName = name;
        SpawnLockOfType(LockTypes.DOOR);
        SetActivity(ActivityType.LOCKPICKING);
    }

    public void FrontDoorOpened()
    {
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (myStore != null) myStore.locked = false;
        SetActivity(ActivityType.STORE);
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
                LoadStore();
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

    private void LoadStore()
    {
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        GameObject go = null;
        for (var i = 0; i < myStore.boxes.Length; i++)
        {
            go = Instantiate(myStore.boxes[0].size == JewelryBoxSizes.SMALL
                ? smallJewelryTable
                : largeJewelryTable);
            switch (i)
            {
                case 1:
                    go.transform.parent = table1Anchor.transform;
                    go.transform.position = table1Anchor.transform.position;
                    break;
                case 2:
                    go.transform.parent = table2Anchor.transform;
                    go.transform.position = table2Anchor.transform.position;
                    break;
                case 3:
                    go.transform.parent = table3Anchor.transform;
                    go.transform.position = table3Anchor.transform.position;
                    break;
                case 4:
                    go.transform.parent = table4Anchor.transform;
                    go.transform.position = table4Anchor.transform.position;
                    break;
                case 5:
                    go.transform.parent = table5Anchor.transform;
                    go.transform.position = table5Anchor.transform.position;
                    break;
            }
        }
        if (myStore != null) myStore.locked = false;
    }
    public void SpawnLockOfType(LockTypes type)
    {
        var spawnPosition = new Vector3(-56, 0.0f, 0);
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
        currentStoreName = StoreName.NONE;
        allStores = new Stores();
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
