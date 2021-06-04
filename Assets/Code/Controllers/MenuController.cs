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

    private GameController gameController;
    private TMP_Text scoreText;
    private GameObject playerLeaveButton;
    private GameObject playerExitButton;
    public enum MenuType
    {
        MAIN,
        HUD,
        GAMEOVER,
        CREDITS
    }
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        mainMenuCanvas = Instantiate(mainMenuCanvas);
        playerHUD = Instantiate(playerHUD);
        playerLeaveButton = playerHUD.transform.Find("LeaveStoreButton").gameObject;
        playerExitButton = playerHUD.transform.Find("ExitButton").gameObject;
        scoreText =playerHUD.transform.Find("HUDBAR/ScoreText").gameObject.GetComponentInChildren<TMP_Text>();
        gameOverCanvas =  Instantiate(gameOverCanvas);
        creditsCanvas =  Instantiate(creditsCanvas);
        ShowMenu(MenuType.MAIN);
    }

    public void HudShowExitOrLeaveButton(bool showExit)
    {
        playerLeaveButton.SetActive(!showExit);
        playerExitButton.SetActive(showExit);
        
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
        switch (type)
        {
            case MenuType.MAIN:
                mainMenuCanvas.SetActive(true);
                break;
            case MenuType.HUD:
                playerHUD.SetActive(true);
                break;
            case MenuType.GAMEOVER:
                gameOverCanvas.SetActive(true);
                break;
            case MenuType.CREDITS:
                creditsCanvas.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "This is impossible! How can a switch statement based on the enum fall outside of its own enumerated values?!");
        }
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
