using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; 
    public BlockCounter blockCounter;
    public ScoreManager scoreManager;
    private GameObject currentBlock;
    private GameObject lastBlock; 

    private float nextSpawnHeight = 5f; 
    private float swayAmount = 1.0f; 
    private float swaySpeed = 2.0f; 
    private float inputDelay = 1.0f; 
    private float lastDropTime; 
    void Update()
    {
        if (currentBlock == null) 
        {
            SpawnBlock();
        }

        if (Input.GetButtonDown("Fire1") && currentBlock != null && Time.time >= lastDropTime + inputDelay) 
        {
            DropBlock();
        }

        if (currentBlock != null)
        {
            SwayBlock();
        }
    }

    private void SpawnBlock()
    {
        Vector3 spawnPosition = new Vector3(0, nextSpawnHeight, 0); 
        currentBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
        Rigidbody rb = currentBlock.GetComponent<Rigidbody>();

        
        if (rb != null)
        {
            rb.isKinematic = true;
        }
      

        //block counter script
        if (blockCounter != null)
        {
            blockCounter.IncrementBlockCount();
        }

        //score manager ref
        if (scoreManager != null)
        {
            scoreManager.IncrementScore();  
        }

    }


    private void DropBlock()
    {
        Rigidbody rb = currentBlock.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; 
            lastBlock = currentBlock; 
            currentBlock = null; 
            UpdateNextSpawnHeight();
            lastDropTime = Time.time; 
        }
       
    }

    private void UpdateNextSpawnHeight()
    {
       
        nextSpawnHeight += 1f; 
    }

    private void SwayBlock()
    {
        float swayPositionX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        Vector3 currentPosition = currentBlock.transform.position;
        currentBlock.transform.position = new Vector3(swayPositionX, currentPosition.y, currentPosition.z);
    }
}
