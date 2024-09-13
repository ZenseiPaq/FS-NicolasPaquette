using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton; 
    public Button quitButton;  
    public Button goMenu;
    public Button quit;
    public bool timerAndScore = false;
    

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
        goMenu.onClick.AddListener(OnMenuButtonClick);
        quit.onClick.AddListener(OnQuitClick);
    }

    void OnStartButtonClick()
    {
        SceneManager.LoadScene("Level1"); 
        timerAndScore = true;
        GameManager manager = GameManager.Instance;
        manager.StartTimer();
        manager.StartScore();
        manager.SetLives();
    }

    void OnQuitButtonClick()
    {
        Application.Quit();
    }
    void OnMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager manager = GameManager.Instance;
        manager.scoreText.enabled = false;
        manager.timerText.enabled = false;
        manager.livesText.enabled = false;  
    }

    void OnQuitClick()
    {
        {
            Application.Quit();
        }
    }

}