using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField] private TMP_Text round;
    [SerializeField] private int totalTour;
    private int tour;
    private int worldChoice;

    void Start()
    {
        worldChoice = PlayerPrefs.GetInt("WorldChoice", 0);
        tour = 0;
        if (worldChoice == 1)
        {
            UpdateTour($"{GetTour()} / {GetTotalTour()}");
        }
        else
        {
            UpdateTour($"{GetTour()}");
        }


    }

    public void AddTour()
    {
        tour++;
    }

    public int GetTour() {  return tour; }

    public int GetTotalTour() { return totalTour;  }

    public void UpdateTour(string text)
    {
        if (round != null)
        {
            round.text = $"{text}";
        }
        else
        {
            Debug.LogError("round is not assigned in the inspector!");
        }
    }
}
