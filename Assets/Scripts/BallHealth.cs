using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHealth : MonoBehaviour
{
    public GameController gameController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Danger"))
        {
            Debug.Log("Ball hitted object " + collision.collider.gameObject.name);
            gameController.GameOver();
        }
    }
}
