using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Parameters
    int numBlocks;
    
    // Cached References
    Loader loader;

    private void Start()
    {
        loader = FindObjectOfType<Loader>();
    }

    public void AddBlock()
    {
        numBlocks++;
        Debug.Log(numBlocks);
    }

    public void RemoveBlock()
    {
        numBlocks--;
        Debug.Log(numBlocks);
        if (numBlocks <= 0)
        {
            loader.LoadNextLevel();
        }
    }
}
