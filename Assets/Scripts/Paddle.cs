using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Parameters
    [Tooltip("The total number of world units as a numeric value.")]
    [SerializeField] float worldUnits = 16f;
    [SerializeField] float paddleYPos = 0.5f;
    [SerializeField] float minX = 1f, maxX = 15f;
    
    void Update()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * worldUnits;
        float clampedMousPosInUnits = Mathf.Clamp(mousePosInUnits, minX, maxX);
        Vector2 paddlePos = new Vector2(clampedMousPosInUnits, paddleYPos);
        this.transform.position = paddlePos;
    }
}
