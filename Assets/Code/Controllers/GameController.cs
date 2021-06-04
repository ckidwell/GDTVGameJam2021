using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private MenuController _menuController;
    private CameraController cameraController;
    private MusicController musicController;
    public GameObject goldLock;
    public GameObject silverLock;
    public GameObject copperLock;
    public GameObject doorLock;
    public int score;
    private bool gameOver = false;
    private bool playerCaught = false;
    //scene game objects to organize in game activities
    [Header("Scene Canvases")] 
    public GameObject lockPickingGO;
    public GameObject jewelryStoreGO;
    public GameObject citySceneGO;
    public GameObject storesGO;
    
    //store table prefabs
    [Header("Store Prefabs")] 
    private UIJewelryStore uiJewelryStore;
    public GameObject smallJewelryTable;
    public GameObject largeJewelryTable;

    [Header("Jewelry Graphics")] 
    public Sprite GOLDRING;
    public Sprite COPPERRING;
    public Sprite SILVERRING;
    public Sprite GOLDCOIN;
    public Sprite DIAMOND;
    public Sprite RUBY;
    public Sprite EMERALD;
    public Sprite SAPPHIRE;
    public Sprite AMETHYST;
    public Sprite PENDANT;

    public GameObject lootCanvas;
    public GameObject lootCash;
    
    // variables to store state of what store we are attempting
    private Stores allStores;
    private GameObject currentlock;
    private GameObject lockpick;
    private StoreName currentStoreName;
    private int currentlyPickingCaseNumber = -1;

    void Start()
    {
        musicController = GameObject.Find("MusicPlayer").GetComponent<MusicController>();
        cameraController = GameObject.Find("Camera Controller").GetComponent<CameraController>();
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        uiJewelryStore = GameObject.Find("JewelryStore").GetComponent<UIJewelryStore>();
        cameraController.SetActiveCamera(CameraActive.OUTSIDE);
        lockpick = GameObject.Find("LOCK_PICK");
       
        SetActivity(ActivityType.CITY);
    }
    
    private void OnEnable()
    {
        JewelLock.OnPickBox += PickBox;
        StoreLock.OnPickDoor += PickDoor; 
    }

    private void OnDisable()
    {
        JewelLock.OnPickBox -= PickBox;
        StoreLock.OnPickDoor -= PickDoor; 
    }

    public void PlayerCaught()
    {
        if (playerCaught)
            return;
        playerCaught = true;
        CheckGameOverStatus();
    }
    public void CheckGameOverStatus()
    {
        if (allStores.stores[0].visited &&
            allStores.stores[1].visited &&
            allStores.stores[2].visited &&
            allStores.stores[3].visited &&
            allStores.stores[4].visited)
        {
            gameOver = true;
        }
        
        if(gameOver || playerCaught)
            GameOver();
    }
    public void AlarmTriggeredForCurrentStore()
    {
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (myStore != null) myStore.alarmTriggered = true;
    }

    public void LeaveDoorWay()
    {
        currentStoreName = StoreName.NONE;
    }
    public void PickDoor(StoreName name)
    {
        Debug.Log("Calling pick front door");
        if (currentStoreName != StoreName.NONE)
            return;
        
        Debug.Log("proceeding in  pick front door");
        currentStoreName = name;
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (myStore != null && myStore.visited)
        {
            var go = Instantiate(lootCash, lootCanvas.transform, true);
            go.transform.localPosition = new Vector3(0, 0, 0);
            _menuController.SetScore(score.ToString());
            go.GetComponent<TMP_Text>().text = "going back is a sure way to get caught...";
            return;
        }

        myStore.playerInside = true;
        SpawnLockOfType(LockTypes.DOOR);
        SetActivity(ActivityType.LOCKPICKING);
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.O))
        {
            GameOver();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            FrontDoorOpened();
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            BoxOpened();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            CheckGameOverStatus();
        }
        #endif
    }
    
    public void BoxOpened()
    {
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (myStore != null)
            myStore.boxes[currentlyPickingCaseNumber].isOpen = true;
        ResetLockPick();
        Destroy(currentlock);
        cameraController.SetActiveCamera(CameraActive.INSIDE);
        jewelryStoreGO.SetActive(true);
        uiJewelryStore.OpenLidForBoxNumber(currentlyPickingCaseNumber);
        lockPickingGO.SetActive(false);
    }
    public void PickBox(StoreName name, LockTypes lockType, int lockNumber)
    {
        currentlyPickingCaseNumber = lockNumber;
        SpawnLockOfType(lockType);
        SetActivity(ActivityType.LOCKPICKING);
    }

    public void FrontDoorOpened()
    {
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (myStore != null) myStore.locked = false;
        myStore.visited = true;
        _menuController.HudShowExitOrLeaveButton(false);
        Destroy(currentlock);
        ResetLockPick();
        SetActivity(ActivityType.STORE);
    }

    public void LeaveStore()
    {
        var myStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (myStore != null)
            myStore.playerInside = false;
        
        musicController.StopTimer();
        currentStoreName = StoreName.NONE;
       
        _menuController.HudShowExitOrLeaveButton(true);
        SetActivity(ActivityType.CITY);
        CheckGameOverStatus();
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
                _menuController.GameOver();
                break;
            case ActivityType.LOSS:
                _menuController.LoseGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "somehow you managed to pass in an invalid activity type");
        }
    }

    private void DeleteOldTables()
    {
        DestroyChildrenImmediately(uiJewelryStore.table1Anchor);
        DestroyChildrenImmediately(uiJewelryStore.table2Anchor);
        DestroyChildrenImmediately(uiJewelryStore.table3Anchor);
        DestroyChildrenImmediately(uiJewelryStore.table4Anchor);
        DestroyChildrenImmediately(uiJewelryStore.table5Anchor);
    }

    private void ResetLockPick()
    {
        lockpick.transform.localPosition = new Vector3(-8.6f, .079f, 0.05f);
    }
    public static void DestroyChildrenImmediately(GameObject go)
    {

        if (go != null)
        {
            Transform goTransform = go.transform;
            foreach (Transform child in goTransform)
            {
               DestroyImmediate(child.gameObject);
            }
        }

    }
    private void LoadStore()
    {
        DeleteOldTables();
        var insideStore = allStores.stores.FirstOrDefault(s => s.name == currentStoreName);
        if (insideStore == null)
            return;
        for (var i = 0; i < insideStore.boxes.Length; i++)
        {
            switch (i)
            {
                case 1:
                    LoadTableInStore(i, insideStore,uiJewelryStore.table1Anchor.transform);
                    break;
                case 2:
                    LoadTableInStore(i, insideStore,uiJewelryStore.table2Anchor.transform );
                    break;
                case 3:
                    LoadTableInStore(i, insideStore,uiJewelryStore.table3Anchor.transform );
                    break;
                case 4:
                    LoadTableInStore(i, insideStore,uiJewelryStore.table4Anchor.transform );
                    break;
                case 5:
                    LoadTableInStore(i, insideStore,uiJewelryStore.table5Anchor.transform );
                    break;
            }
        }
        uiJewelryStore.GetLidsAndGemColliders();
        uiJewelryStore.DisableAllGemColliders();
        insideStore.locked = false;
    }

    private void LoadTableInStore(int i, InsideStore insideStore, Transform t)
    {
        var go = Instantiate(insideStore.boxes[i].size == JewelryBoxSizes.SMALL
            ? smallJewelryTable
            : largeJewelryTable, t);
        go.transform.position = t.position;
        go.name = "table" + i;
        var jewelLock = go.GetComponentInChildren<JewelLock>();
        jewelLock.caseNumber = i;
        jewelLock.lockType = insideStore.boxes[i].lockType;
        PopulateJewelryInJewelryTable(go, insideStore, i);
    }
    private void PopulateJewelryInJewelryTable(GameObject table, InsideStore store, int tableNum)
    {
        var jsInBox = table.GetComponentsInChildren<JSpot>();
        int count = 0;
        foreach (var jewelry in store.boxes[tableNum].itemsInside)
        {
            switch (jewelry.jewelryType)
            {
                case JewelryTypes.GOLDRING:
                    jsInBox[count].GetComponent<Image>().sprite = GOLDRING;
                    break;
                case JewelryTypes.COPPERRING:
                    jsInBox[count].GetComponent<Image>().sprite = COPPERRING;
                    break;
                case JewelryTypes.SILVERRING:
                    jsInBox[count].GetComponent<Image>().sprite = SILVERRING;
                    break;
                case JewelryTypes.GOLDCOIN:
                    jsInBox[count].GetComponent<Image>().sprite = GOLDCOIN;
                    break;
                case JewelryTypes.DIAMOND:
                    jsInBox[count].GetComponent<Image>().sprite = DIAMOND;
                    break;
                case JewelryTypes.RUBY:
                    jsInBox[count].GetComponent<Image>().sprite = RUBY;
                    break;
                case JewelryTypes.EMERALD:
                    jsInBox[count].GetComponent<Image>().sprite = EMERALD;
                    break;
                case JewelryTypes.SAPPHIRE:
                    jsInBox[count].GetComponent<Image>().sprite = SAPPHIRE;
                    break;
                case JewelryTypes.AMETHYST:
                    jsInBox[count].GetComponent<Image>().sprite = AMETHYST;
                    break;
                case JewelryTypes.PENDANT:
                    jsInBox[count].GetComponent<Image>().sprite = PENDANT;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            count++;
        }
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
        score = 0;
        gameOver = false;
        playerCaught = false;
        _menuController.HudShowExitOrLeaveButton(true);
        _menuController.SetScore(score.ToString());
        currentStoreName = StoreName.NONE;
        allStores = new Stores();
    }

    public void GameOver()
    {
        if (playerCaught)
        {
            SetActivity(ActivityType.LOSS);
            return;
        }
            SetActivity(ActivityType.WIN);
    }

    public void LootItem(Jewelry jewelry)
    {
        if (jewelry != null)
        {
            Debug.Log("just looted a : " + jewelry.jewelryType);
        }

        var lootAmount = UnityEngine.Random.Range(300, 1500);
        var go = Instantiate(lootCash, lootCanvas.transform, true);
        go.transform.localPosition = new Vector3(0, 0, 0);
        score += lootAmount;
        _menuController.SetScore(score.ToString());
        go.GetComponent<TMP_Text>().text = lootAmount.ToString() + ".00";
    }
    public void ExitToMain()
    {
        _menuController.GoMainMenu();
    }
}
