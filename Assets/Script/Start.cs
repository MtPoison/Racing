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
    [SerializeField] private GameManager gameManager;
    private float currentTime = 3;
    private bool isRunning;
    private bool test;

    void Start()
    {
        isRunning = false;
        test = true;
        
        UpdateCountdownText();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();
            timer.StopCountdown();

            if (currentTime < 0)
            {
                currentTime = 0;
                player.SetActive(true);
                start.SetActive(false);
                gameManager.EndStarting();
                isRunning = false;
                test = false;
            }
        }
    }

    public void IsCountdown()
    {
        isRunning = true;
    }

    public bool GetTest() {  return test; }
    public void GetTest(bool _test) {  test = _test; }
    public bool GetIsRunning() {  return isRunning; }

    void UpdateCountdownText()
    {
        countdownText.text = $"{Mathf.CeilToInt(currentTime):D2}";
    }
}
