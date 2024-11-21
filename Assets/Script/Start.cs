using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Starting : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TimerCount timer;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject start;
    private float currentTime = 3;
    private bool isRunning;

    void Start()
    {
        isRunning = true;
        UpdateCountdownText();
    }

    void Update()
    {
        if(isActiveAndEnabled) { 
            if (isRunning)
            {
                currentTime -= Time.deltaTime;
                UpdateCountdownText();

                if (currentTime <= 0)
                {
                    currentTime = 0;
                    isRunning = false;
                    timer.ActiveCountdown();
                    player.SetActive(true);
                    start.SetActive(false);
                }
            }
        }
    }

    public void StopCountdown()
    {
        isRunning = false;
    }


    void UpdateCountdownText()
    {
        countdownText.text = $"{Mathf.CeilToInt(currentTime):D2}";
    }
}
