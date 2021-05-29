using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private MenuController _menuController;
    public GameObject goldLock;
    public GameObject silverLock;
    public GameObject copperLock;
    public GameObject doorLock;
    private GameObject currentlock;

  
    void Start()
    {
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        SpawnLockOfType(LockTypes.GOLD);
    }
    
    void Update()
    {
        
    }

    public void SpawnLockOfType(LockTypes type)
    {
        switch (type)
        {
            case LockTypes.DOOR:
                currentlock = Instantiate(doorLock);
                break;
            case LockTypes.COPPER:
                currentlock = Instantiate(copperLock);
                break;
            case LockTypes.SILVER:
                currentlock = Instantiate(silverLock);
                break;
            case LockTypes.GOLD:
                currentlock = Instantiate(goldLock);
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
