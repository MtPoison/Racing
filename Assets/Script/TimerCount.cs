using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    private float currentTime;
    private bool isRunning;
    private int worldChoice;
    void Start()
    {
        worldChoice = PlayerPrefs.GetInt("WorldChoice", 0);
        isRunning = true;
        if(worldChoice == 1)
        {
            currentTime = 70f;
        }
        else {
            currentTime = 150f;
        }
        
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
        print("coucouc");
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
