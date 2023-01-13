using System.Collections;
using UnityEngine;
using TMPro;

namespace BallPhysicsGame
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _timerUI;
        [SerializeField] float _timerLimit = 300f;
        [SerializeField] GameManager _gameManager;

        private float currentTime = 0f;

        public void ResetTimer()
        {
            currentTime = _timerLimit;
            StopAllCoroutines();
            StartCoroutine(StartTimer());
            _timerUI.text = "" + currentTime;
        }

        IEnumerator StartTimer()
        {
            while (currentTime > 0)
            {
                if (!_gameManager.isGameStarted)
                    yield break;

                yield return new WaitForSeconds(1);
                currentTime--;
                _timerUI.text = "" + currentTime;
            }

            Debug.Log("Time Finished");
            _gameManager.GameOver();
        }
    } 
}
