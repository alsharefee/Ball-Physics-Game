using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallPhysicsGame
{
    public class GameManager : MonoBehaviour
    {
        [HideInInspector] public bool Paused = false;
        [HideInInspector] public bool isGameStarted = false;

        [SerializeField] GameObject _pauseUIPanel = null;
        [SerializeField] GameObject _gameStartUIPanel = null;
        [SerializeField] GameObject _gameOverUIPanel = null;
        [SerializeField] GameObject _gameWonUIPanel = null;
        [SerializeField] GameObject _fireWorksVFX;

        [SerializeField] BallController _ballController;
        [SerializeField] PointsCollector _pointsCollector;
        [SerializeField] Timer _timer;
        [SerializeField] ObstaclesManager _obstaclesManager;
        [SerializeField] SaveData _saveData;

        private SpawnRandomGroupTrigger[] _spawnRandomGroupsTrigger;
        private DateTime _sessionStarted;

        private void Start()
        {
            FindSpawingTriggers();
        }

        private void FindSpawingTriggers()
        {
            _spawnRandomGroupsTrigger = FindObjectsOfType<SpawnRandomGroupTrigger>();
        }

        public void StartGame()
        {
            ResetGame();
            isGameStarted = true;
            _gameStartUIPanel.SetActive(false);
            _timer.ResetTimer();
            ResetAllGroupsSpawningTriggers();
            _sessionStarted = DateTime.Now;
            Cursor.visible = false;
        }

        private void ResetAllGroupsSpawningTriggers()
        {
            foreach (var trigger in _spawnRandomGroupsTrigger)
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
            _pauseUIPanel.SetActive(true);
            Cursor.visible = true;
        }

        void ResumeGame()
        {
            Time.timeScale = 1f;
            Paused = false;
            _pauseUIPanel.SetActive(false);
            Cursor.visible = false;
        }

        public void GameOver()
        {
            SaveSessionData();
            _gameOverUIPanel.SetActive(true);
            isGameStarted = false;
            Cursor.visible = true;
        }

        public void GameWon()
        {
            SaveSessionData();
            _gameWonUIPanel.SetActive(true);
            isGameStarted = false;
            _fireWorksVFX.SetActive(true);
            Cursor.visible = true;
        }

        void ResetGame()
        {
            ResumeGame();
            _gameOverUIPanel.SetActive(false);
            _gameWonUIPanel.SetActive(false);
            _pointsCollector.ResetPoints();
            _obstaclesManager.ResetObstacles();
            _ballController.ResetBall();
            _fireWorksVFX.SetActive(false);
        }

        void SaveSessionData()
        {
            GameSessionData thisGameSessionData = new GameSessionData()
            {
                timePlayed = (DateTime.Now - _sessionStarted).ToString(),
                timeJasonMade = DateTime.Now.ToString(),
                gameName = SceneManager.GetActiveScene().name,
                score = _pointsCollector.PointsCollected
            };

            _saveData.SaveIntoJson(thisGameSessionData);
        }
    } 
}
