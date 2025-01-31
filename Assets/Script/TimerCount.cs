using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    private float currentTime;
    [SerializeField] private float time1; 
    [SerializeField] private float time2; 
    private bool isRunning;
    private int worldChoice;
    void Start()
    {
        worldChoice = PlayerPrefs.GetInt("WorldChoice", 0);
        isRunning = false;
        if(worldChoice == 1)
        {
            currentTime = time1;
        }
        else {
            currentTime = time2;
        }
        
        UpdateCountdownText();
        print(isRunning);
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
