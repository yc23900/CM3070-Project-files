using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;  
    private float timer = 0;    
    private int secondsPassed = 0;  

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;  

        int currentSecond = (int)timer;  

        
        if (currentSecond > secondsPassed)
        {
            secondsPassed = currentSecond;  
            UpdateTimerDisplay(secondsPassed);  
        }
    }

    void UpdateTimerDisplay(int seconds)
    {
        if (timerText != null)
        {
            timerText.text = seconds.ToString(); 
        }
    }

    public int GetSeconds()
    {
        return secondsPassed;
    }
}