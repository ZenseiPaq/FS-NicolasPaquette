using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Canvas endGameCanvas;
    public TextMeshProUGUI scoreText;
    public string nextLevelSceneName;
    public string currentSceneName;
    public Scene scene;
    public Canvas dead;
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;
    private bool isInMenu = true;
    private int playerScore = 0;
    private int maxLives = 3;
    public static int currentLives;
    public bool canScore = false;
    public TextMeshProUGUI livesText;
    public Collider2D playerCollider;
    public Collider2D[] enemyCollider;
    public bool canTimerRun;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        SceneManager.LoadScene("MainMenu");
        UpdateLivesUI();
        scoreText.enabled = false;
        timerText.enabled = false;
        livesText.enabled = false;
        dead.enabled = false;

    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerUI();
        if (dead.enabled = true && Input.GetKeyDown(KeyCode.R))
        {
            dead.enabled = false;
            RetryLevel();
        }
    }

    public void AddPoints(int points)
    {
        playerScore += points;
        UpdateScoreUI();
    }


    private void UpdateScoreUI()
    {
        if (canScore == false)
        {
            scoreText.enabled = false;
        }
        if (canScore == true)
        {
            scoreText.enabled = true;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + playerScore;
            }
        }
    }



    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelSceneName);

        if(scene.name == "Victory")
        {
            StopTimer();
            Time.timeScale = 0f;
        }
    }

    public void ResetScore()
    {
        playerScore = 0;
        UpdateScoreUI() ;
    }

    void UpdateTimerUI()
    {
        if (isTimerRunning)
        {
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);

            timerText.text = $"{seconds:00}";
        }
        
    }
    public void StartTimer()
    {       
            timerText.enabled = true;
            isTimerRunning = true;
            elapsedTime = 0f;
            UpdateTimerUI();
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        
    }

    public void RetryLevel()
    {
        currentLives--;
        UpdateLivesUI();
        Time.timeScale = 1f;
        if (currentLives > 0)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            ResetScore();
        }       
    }

    public void StartScore()
    {
        scoreText.enabled = true;
        canScore = true;
        livesText.enabled = true;
    }

    public void UpdateLivesUI()
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void YouLost()
    {
        dead.enabled = true;
        Time.timeScale = 0.1f;
    }
    public void DeathCanvasDisable()
    {
        dead.enabled = false;
    }

    public void SetLives()
    {
        currentLives = maxLives;
        UpdateLivesUI();
    }

}    