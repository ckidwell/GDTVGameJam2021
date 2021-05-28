using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private MenuController _menuController;
    public GameObject goldLock;
    private GameObject currentlock;
    void Start()
    {
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        currentlock = Instantiate(goldLock);
    }
    
    void Update()
    {
        
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
