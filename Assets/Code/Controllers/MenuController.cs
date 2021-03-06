using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField]
    private GameObject playerHUD;
    [SerializeField]
    private GameObject gameOverCanvas;
    [SerializeField]
    private GameObject creditsCanvas;
    [SerializeField]
    private GameObject failureCanvas;
    
    private GameController gameController;
    private TMP_Text scoreText;
    private GameObject playerLeaveButton;
    private GameObject playerExitButton;
    private GameObject playerGetAwayButton;
    private GameObject playerLeaveDoorButton;
    public enum MenuType
    {
        MAIN,
        HUD,
        GAMEOVER,
        CREDITS,
        FAILURE
    }
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        mainMenuCanvas = Instantiate(mainMenuCanvas);
        playerHUD = Instantiate(playerHUD);
        failureCanvas = Instantiate(failureCanvas);
        playerLeaveButton = playerHUD.transform.Find("LeaveStoreButton").gameObject;
        playerExitButton = playerHUD.transform.Find("ExitButton").gameObject;
        playerGetAwayButton = playerHUD.transform.Find("GetawayButton").gameObject;
        playerLeaveDoorButton = playerHUD.transform.Find("LeaveDoorButton").gameObject;
        scoreText =playerHUD.transform.Find("HUDBAR/ScoreText").gameObject.GetComponentInChildren<TMP_Text>();
        gameOverCanvas =  Instantiate(gameOverCanvas);
        creditsCanvas =  Instantiate(creditsCanvas);
        ShowMenu(MenuType.MAIN);
    }

    public void HudShowExitOrLeaveButton(bool showExit)
    {
        playerLeaveButton.SetActive(!showExit);
        playerExitButton.SetActive(showExit);
        // buggy always set to false for now
        playerLeaveDoorButton.SetActive(false);
    }

    public void ShowGetAwayButton()
    {
        playerGetAwayButton.SetActive(true);
    }
    public void HideHUDButtonsWhilePicking()
    {
        playerLeaveButton.SetActive(false);
        playerExitButton.SetActive(false);
        playerGetAwayButton.SetActive(false);
        playerLeaveDoorButton.SetActive(false);
    }
    public void SetScore(string val)
    {
        if(scoreText == null)
            scoreText = playerHUD.transform.Find("HUDBAR/ScoreText").gameObject.GetComponentInChildren<TMP_Text>();
        scoreText.text = val;
    }
    public void PlayGame()
    {
        ShowMenu(MenuType.HUD);
        gameController.StartNewGame();
    }

    private void ShowMenu(MenuType type)
    {
        mainMenuCanvas.SetActive(false);
        playerHUD.SetActive(false);
        gameOverCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        failureCanvas.SetActive(false);
        switch (type)
        {
            case MenuType.MAIN:
                mainMenuCanvas.SetActive(true);
                break;
            case MenuType.HUD:
                ShowGetAwayButton();
                playerHUD.SetActive(true);
                break;
            case MenuType.GAMEOVER:
                gameOverCanvas.SetActive(true);
                break;
            case MenuType.CREDITS:
                creditsCanvas.SetActive(true);
                break;
            case MenuType.FAILURE:
                failureCanvas.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "This is impossible! How can a switch statement based on the enum fall outside of its own enumerated values?!");
        }
    }

    public void LoseGame()
    {
        ShowMenu(MenuType.FAILURE);
    }
    public void GameOver()
    {
        ShowMenu(MenuType.GAMEOVER);
    }
    public void QuitGame()
    {
        
    }

    public void GoMainMenu()
    {
        ShowMenu(MenuType.MAIN);
    }
}

