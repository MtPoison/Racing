using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private float startTime;
    private float currentTime;
    private bool isRunning;

    void Start()
    {
        isRunning = true;
        currentTime = startTime;
        UpdateCountdownText();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();

            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
            }
        }
    }

    public void StopCountdown()
    {
        isRunning = false;
    }

    public void ActiveCountdown()
    { 
        isRunning = true; 
    }


    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); 
        int seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = $"{minutes:D2}:{seconds:D2}";
    }

    public float getCurentime() { return currentTime; }
}
