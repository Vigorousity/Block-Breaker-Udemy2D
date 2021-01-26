using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int numBlocks;
    [SerializeField] Loader loader;

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
