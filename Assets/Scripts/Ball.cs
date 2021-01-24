using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchSpeed = 15f;
    [Tooltip("World units divided by 2")]
    [SerializeField] float halfWorldUnits = 8f;

    // State
    Vector2 paddleToBallVector;
    bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = this.transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            launched = true;
            float launchAngle = paddle1.transform.position.x - halfWorldUnits;
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchAngle, launchSpeed);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        this.transform.position = paddlePos + paddleToBallVector;
    }
}
