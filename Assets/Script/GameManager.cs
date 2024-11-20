using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject UiCanvas;
    [SerializeField] private GameObject player;
    [SerializeField] private Round round;
    [SerializeField] private TimerCount timer;
    [SerializeField] private TMP_Text bestTime;
    [SerializeField] private TMP_Text tempsRestant;
    [SerializeField] private TMP_Text Etat;
    private End end;

    private void Start() 
    {
        var manager = FindObjectOfType<End>();
        end = manager;
        endGameCanvas.SetActive(false);
        player.SetActive(true);
    }
    private void Update()
    {
        if(FinishAllTour() || timer.getCurentime() == 0)
        {
            var manager = FindObjectOfType<End>();
            if (FinishAllTour())
            {
                timer.StopCountdown();
                Etat.text = "Win";
            }
            else
            {
                Etat.text = "Loose";
            }
            tempsRestant.text = $"{ConvertMinute(timer.getCurentime())}";
            
            GetMinValueAndIndex(end.GetTours());
            endGameCanvas.SetActive(true);
            player.SetActive(false);
            
        }
    }

    public bool FinishAllTour()
    {
        if(round.GetTour() > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   
    public void GetMinValueAndIndex(List<float> floats)
    {
        if (floats.Count == 0)
        {
            throw new ArgumentException("La liste est vide !");
        }

        float minValue = floats[0];
        int minIndex = 0;

        for (int i = 1; i < floats.Count; i++)
        {
            if (floats[i] < minValue)
            {
                minValue = floats[i];
                minIndex = i;
            }
        }
        bestTime.text = $"Meilleure tour {minIndex + 1:D2} : {ConvertMinute(minValue)}";
    }

    private string ConvertMinute( float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return $"{minutes:D2}:{seconds:D2}";
    }
}
