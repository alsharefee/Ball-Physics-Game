using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    public float timerLimit = 300f;
    private float currentTime = 0f;

    public GameController gameController;

    public void ResetTimer()
    {
        currentTime = timerLimit;
        StopAllCoroutines();
        StartCoroutine(StartTimer());
        timerUI.text = "" + currentTime;
    }

    IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            if (!gameController.isGameStarted)
                yield break; 

            yield return new WaitForSeconds(1);
            currentTime--;
            timerUI.text = "" + currentTime;
        }

        Debug.Log("Time Finished");
        gameController.GameOver();
    }

}
