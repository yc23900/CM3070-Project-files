using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;  
    private int score = -1;  

    void Start()
    {
        //text meshpro error test
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
            if (scoreText == null)
            {
                Debug.LogError("tmp not found");
            }
        }
        UpdateScoreText();
    }

    public void IncrementScore(int amount = 1)  
    {
        score += amount;  
        UpdateScoreText();  
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; 
        }
    }

    public int GetScore()
    {
        return score; 
    }
}