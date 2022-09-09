using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseUIPanel = null;
    public GameObject gameStartUIPanel = null;
    public GameObject gameOverUIPanel = null;
    public GameObject gameWonUIPanel = null;
    public GameObject fireWorksVFX;

    [HideInInspector] public bool Paused = false;
    [HideInInspector] public bool isGameStarted = false;

    public BallController ballController;
    public PointsCollector pointsCollector;
    public Timer timer;
    public ObstaclesManager obstaclesManager;
    public SaveData saveData;

    private SpawnRandomGroupTrigger[] spawnRandomGroupsTrigger;
    private DateTime sessionStarted;


    private void Start()
    {
        
        spawnRandomGroupsTrigger = FindObjectsOfType<SpawnRandomGroupTrigger>();
    }
    public void StartGame()
    {
        ResetGame();
        isGameStarted = true;
        gameStartUIPanel.SetActive(false);
        timer.ResetTimer();
        ResetAllGroupsSpawningTriggers();
        sessionStarted = DateTime.Now;
        Cursor.visible = false;
    }

    private void ResetAllGroupsSpawningTriggers()
    {
        foreach (var trigger in spawnRandomGroupsTrigger)
            trigger.ResetTrigger();
    }

    public void PauseOrResumeGame()
    {
        if (Paused)
            ResumeGame();
        else
            PauseGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        Paused = true;
        pauseUIPanel.SetActive(true);
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Paused = false;
        pauseUIPanel.SetActive(false);
        Cursor.visible = false;
    }

    public void GameOver()
    {
        SaveSessionData();
        gameOverUIPanel.SetActive(true);
        isGameStarted = false;
        Cursor.visible = true;
    }

    public void GameWon()
    {
        SaveSessionData();
        gameWonUIPanel.SetActive(true);
        isGameStarted = false;
        fireWorksVFX.SetActive(true);
        Cursor.visible = true;
    }

    void ResetGame()
    {
        ResumeGame();
        gameOverUIPanel.SetActive(false);
        gameWonUIPanel.SetActive(false);
        pointsCollector.ResetPoints();
        obstaclesManager.ResetObstacles();
        ballController.ResetBall();
        fireWorksVFX.SetActive(false);
    }

    void SaveSessionData()
    {
        GameSessionData thisGameSessionData = new GameSessionData()
        {
            timePlayed = (DateTime.Now - sessionStarted).ToString(),
            timeJasonMade = DateTime.Now.ToString(),
            gameName = SceneManager.GetActiveScene().name,
            score = pointsCollector.pointsCollected
        };

        saveData.SaveIntoJson(thisGameSessionData);
    }
}
