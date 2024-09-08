using UnityEngine;
using TMPro;

public class BlockCounter : MonoBehaviour
{
    public int maxBlocks = 50; 
    private int currentBlockCount = 0; 

    public TMP_Text blocksLeftText; 

    public GameOverScreen gameOverScreen;

    void Start()
    {
        
        if (blocksLeftText == null)
        {
            blocksLeftText = GameObject.Find("BlocksLeftText").GetComponent<TMP_Text>();
        }
        UpdateBlocksLeftText();
    }

    public void IncrementBlockCount()
    {
        currentBlockCount++; 
        UpdateBlocksLeftText();

       
        if (currentBlockCount >= maxBlocks)
        {
            gameOverScreen.TriggerGameOver(); 
        }
    }

    private void UpdateBlocksLeftText()
    {
        if (blocksLeftText != null)
        {
            int blocksLeft = maxBlocks - currentBlockCount;
            blocksLeftText.text = "Blocks Left: " + blocksLeft;
        }
    }
}