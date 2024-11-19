using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField] private TMP_Text round;
    [SerializeField] private float totalTour;
    private int tour;

    void Start()
    {
        tour = 1;  
        round.text = $"{tour}/{totalTour}";
        
    }

    public void AddTour()
    {
        tour++;
        UpdateTour();
    }

    public int GetTour() {  return tour; }

    void UpdateTour()
    {
        if (round != null)
        {
            round.text = $"{tour}/{totalTour}";
        }
        else
        {
            Debug.LogError("round is not assigned in the inspector!");
        }
    }
}
