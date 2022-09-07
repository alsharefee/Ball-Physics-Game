using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameController gameController = null;
    public Rigidbody rig;
   
    public float defaultForce = 3;
    public float boostSpeed = 6;
    public float jumpForceMultiplayer;

    private float currentForce;
    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;

    private Vector3 ballDefaultPosition;

    private void Start()
    {
        ballDefaultPosition = transform.position;
    }

    void Update()
    {
        if (!gameController.isGameStarted)
            return;

        GetInput();
        MoveBall();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape))
            gameController.PauseOrResumeGame();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            currentForce = boostSpeed;
        else
            currentForce = defaultForce;
    }

    private void MoveBall()
    {
        rig.AddForce(new Vector3
            (horizontalInput * currentForce,
            jumpInput * jumpForceMultiplayer,
            verticalInput * currentForce
            ), ForceMode.Force);
    }

    public void ResetBall()
    {
        rig.isKinematic = true;
        transform.SetPositionAndRotation(ballDefaultPosition, Quaternion.identity);
        rig.isKinematic = false;
    }
}
