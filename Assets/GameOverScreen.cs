using UnityEngine;
using TMPro; 

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverText; 
    public BlockSpawner blockSpawn; 
    public ScoreManager scoreManager; 
    public TimerScript timerScript;  

    void Start()
    {
        gameOverText.SetActive(false); 
    }

    public void TriggerGameOver()
    {
        //disable scripts
        blockSpawn.enabled = false;
        scoreManager.enabled = false;
        timerScript.enabled = false; 

      
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
         
        }
    }
}