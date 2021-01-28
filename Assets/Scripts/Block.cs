using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Parameters
    [SerializeField] AudioClip breakSound;

    // Cached References
    Level level;
    GameState gameState;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameState = FindObjectOfType<GameState>();

        level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.RemoveBlock();
        gameState.AddToScore();
        Destroy(gameObject);
    }
}
