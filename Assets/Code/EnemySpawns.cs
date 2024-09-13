using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawns : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 10;
    public float spawnRate = 2f;
    public Canvas endScreen;
    public int amountEnemy;
    public GameManager manager;
    private int currentEnemyCount = 0;
    private int enemyKillCount = 0;
    public Canvas final;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        endScreen.enabled = false;
    }

    private void Update()
    {
        if (endScreen.enabled && Input.GetKeyDown(KeyCode.Space))
        {
            GoToNextLevel();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GoToNextLevel();
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemies)
        {
            yield return new WaitForSeconds(spawnRate);

            int spawnIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

            currentEnemyCount++;
        }
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        amountEnemy--;

        if (amountEnemy <= 0)
        {
            endScreen.enabled = true;
            StopAllCoroutines();
        }
    }

    void GoToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            endScreen.enabled = false;
        }        
        if(nextSceneIndex == 4)
        {
            GameManager manager = GameManager.Instance;
            manager.StopTimer();
            if (final != null)
            {
                final.enabled = true;
            }
        }
    }   
}