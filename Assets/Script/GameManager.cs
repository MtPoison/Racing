using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject UiCanvas;
    [SerializeField] private GameObject player;
    [SerializeField] private End end;
    [SerializeField] private Round round;
    [SerializeField] private TimerCount timer;
    [SerializeField] private TMP_Text bestTime;

    private void Start() 
    {
        endGameCanvas.SetActive(false);
        player.SetActive(true);
    }
    private void Update()
    {
        if(round.GetTour() > 3 || timer.getCurentime() == 0)
        {
            BestTime();
            endGameCanvas.SetActive(true);
            player.SetActive(false);
            
        }
    }

    private void BestTime()
    { 
        end.BestTime();

        string text = ConvertMinute(end.GetBestTime());
        bestTime.text = $"Meilleure tour {end.GetBestTour() + 1:D2} : {text}";
    }

    private string ConvertMinute( float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return $"{minutes:D2}:{seconds:D2}";
    }
}
