using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    public float startTime = 3000f;

    private float currentTime;

    void Start()
    {
        currentTime = startTime;
        UpdateCountdownText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(0, currentTime);
            UpdateCountdownText();
        }
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); 
        int seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = $"{minutes:D2}:{seconds:D2}";
    }
}
