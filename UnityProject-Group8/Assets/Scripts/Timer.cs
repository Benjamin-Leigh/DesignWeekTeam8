using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float elapsedTime = 60;
    public float counter = 60;
    
    void Update()
    {
        CountDownTimer();

    }

    void CountDownTimer()
    {
        elapsedTime -= Time.deltaTime;
        
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime / 60);
       // TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        TimerText.text = elapsedTime.ToString("F0");
        if (elapsedTime <= 0)
        {
            elapsedTime = 0;

        }
    }
}
