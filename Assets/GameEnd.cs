using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Button menu;
    public Button quit;
    private void Start()
    {
        menu.onClick.AddListener(OnStartButtonClick);
        quit.onClick.AddListener(OnQuitButtonClick);
    }

    void OnStartButtonClick()
    {
        // Load the game scene
        SceneManager.LoadScene("MainMenu"); 
    }

    void OnQuitButtonClick()
    {
        Application.Quit();
    }
}

