using UnityEngine;

/// <summary>
/// Control the ball movement.
/// </summary>
namespace BallPhysicsGame
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] GameManager _gameManager = null;
        [SerializeField] Rigidbody _rig;

        [SerializeField] float _defaultForce = 3;
        [SerializeField] float _boostSpeed = 6;
        [SerializeField] float _jumpForceMultiplayer;

        private float _currentForce;
        private float _horizontalInput;
        private float _verticalInput;
        private float _jumpInput;

        private Vector3 _ballDefaultPosition;

        private void Start()
        {
            if (!_rig)
            {
                _rig = GetComponent<Rigidbody>();
            }

            SetStartingPositionAsDefault();
        }

        private void SetStartingPositionAsDefault()
        {
            _ballDefaultPosition = transform.position;
        }

        void FixedUpdate()
        {
            if (!_gameManager.isGameStarted)
                return;

            GetInput();
            MoveBall();
        }

        private void GetInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Escape))
                _gameManager.PauseOrResumeGame();

            _currentForce = Input.GetKeyDown(KeyCode.LeftShift) ? _boostSpeed : _defaultForce;
        }

        private void MoveBall()
        {
            _rig.AddForce(new Vector3
                (_horizontalInput * _currentForce,
                _jumpInput * _jumpForceMultiplayer,
                _verticalInput * _currentForce
                ), ForceMode.Force);
        }

        public void ResetBall()
        {
            _rig.isKinematic = true;
            transform.SetPositionAndRotation(_ballDefaultPosition, Quaternion.identity);
            _rig.isKinematic = false;
        }
    } 
}
