using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseUIPanel = null;
    public GameObject gameStartUIPanel = null;
    public GameObject gameOverUIPanel = null;

    [HideInInspector] public bool Paused = false;
    [HideInInspector] public bool isGameStarted = false;

    public BallController ballController;
    public PointsCollector pointsCollector;
    public Timer timer;
    public ObstaclesManager obstaclesManager;

    private SpawnRandomGroupTrigger[] spawnRandomGroupsTrigger;

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
    }

    private void ResetAllGroupsSpawningTriggers()
    {
        foreach (var trigger in spawnRandomGroupsTrigger)
        {
            trigger.ResetTrigger();
        }
    }

    public void PauseOrResumeGame()
    {
        if (!Paused)
            PauseGame();
        else
            ResumeGame();
    }
     void PauseGame()
    {
        Time.timeScale = 0f;
        Paused = true;
        pauseUIPanel.SetActive(true);
    }

     void ResumeGame()
    {
        Time.timeScale = 1f;
        Paused = false;
        pauseUIPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUIPanel.SetActive(true);
        isGameStarted = false;
    }

    void ResetGame()
    {
        gameOverUIPanel.SetActive(false);
        ResumeGame();
        pointsCollector.ResetPoints();
        obstaclesManager.ResetObstacles();
        ballController.ResetBall();
    }
}
