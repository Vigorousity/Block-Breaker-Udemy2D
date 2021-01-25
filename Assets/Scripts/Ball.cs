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
    
    //[SerializeField] AudioClip[] ballSounds;

    // State
    Vector2 paddleToBallVector;
    bool launched = false;

    // Cached Component References
    AudioSource myAudioSource;

    void Start()
    {
        paddleToBallVector = this.transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (launched)
        {
            myAudioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            AudioClip clip = myAudioSource.clip;
            myAudioSource.PlayOneShot(clip);
        }
    }
}
