using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float elapsedTime = 60;
    public float counter = 60;
    float timer = 1f;
    public float roundTimer = 60f;
    public AudioClip TimerTick;
    public AudioSource AudioSource;


    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        CountDownTimer();
        PlaySound();
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
        if (elapsedTime <= 0)
        {
            SceneManager.LoadScene("GameOver");

        }
    }
    
    void TickSound()
    {
        InvokeRepeating("TimerTick", 0.001f, 2f);        
    }

    void PlaySound()
    {
        AudioSource.clip = TimerTick;
        AudioSource.Play();

    }
}
