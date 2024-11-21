using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField] private TMP_Text round;
    [SerializeField] private int totalTour;
    private int tour;

    void Start()
    {
        tour = 1;  
        round.text = $"{tour}/{totalTour}";
        
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
