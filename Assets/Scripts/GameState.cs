using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] [Range(0.1f, 10f)] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 7;
    [SerializeField] TextMeshProUGUI scoreLabel;

    // State Variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStateCount = FindObjectsOfType<GameState>().Length;

        if (gameStateCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreLabel();
    }

    void Update()
    {
        ModifyTimeScale();
    }

    private void ModifyTimeScale()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        UpdateScoreLabel();
    }

    private void UpdateScoreLabel()
    {
        scoreLabel.text = currentScore.ToString();
    }
}
