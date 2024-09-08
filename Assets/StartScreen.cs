using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject startText; 
    public BlockSpawner blockSpawn; 
    public ScoreManager scoreManager;
    public TimerScript timerScript;
    public BlockCounter blockCounter;

    private bool gameStarted = false; 

    void Start()
    {
       
        blockSpawn.enabled = false;
        scoreManager.enabled = false;
        timerScript.enabled = false;
        blockCounter.enabled = false;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !gameStarted)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        startText.SetActive(false); 
        blockSpawn.enabled = true; 
        scoreManager.enabled = true;
        timerScript.enabled = true;
        blockCounter.enabled = true;
    }
}