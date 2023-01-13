using UnityEngine;

namespace BallPhysicsGame
{
    public class BallHealth : MonoBehaviour
    {
        [SerializeField] GameManager _gameManager;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Danger"))
                _gameManager.GameOver();
        }
    } 
}
