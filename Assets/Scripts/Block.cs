using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockBreakParticleVFX;

    // Cached References
    Level level;
    GameState gameState;

    private void Start()
    {
        AddBlockToLevel();
    }

    /* AddBlockToLevel checks to see if the block is breakable. 
     * If true, it caches references to the Level and Game State game objects. 
     * It then calls a public method in Level to add itself to the block count. 
     */
    private void AddBlockToLevel()
    {
        if (CompareTag("Breakable"))
        {
            level = FindObjectOfType<Level>();
            gameState = FindObjectOfType<GameState>();

            level.AddBlock();
        }
    }

    /* Defines the OnCollisionEnter2D event.
     * If the block is breakable, it calls the DestroyBlock method.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            DestroyBlock();
        }
    }

    /* DestroyBlock calls a series of methods to perform operations related to block destruction.
     * This includes: triggering SFX, removing block from count, adding to game score, triggering
     * particle VFX, and finally destroying itself.
     */
    private void DestroyBlock()
    {
        TriggerBreakSFX();
        level.RemoveBlock();
        gameState.AddToScore();
        TriggerBreakParticleVFX();
        Destroy(gameObject);
    }

    /* TriggerBreakSFX creates an audio source at the position of the game camera and plays the associated clip.
     */
    private void TriggerBreakSFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    /* TriggerBreakParticleVFX instantiates a new game object at this object's position to play a VFX.
     * After 0.5 seconds, the VFX game object is then destroyed.
     */
    private void TriggerBreakParticleVFX()
    {
        GameObject blockBreakParticles = Instantiate(blockBreakParticleVFX, transform.position, transform.rotation);
        Destroy(blockBreakParticles, 0.5f);
    }
}
