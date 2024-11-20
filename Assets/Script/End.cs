using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class End : MonoBehaviour
{
    [SerializeField] Round round;
    private CheckpointManager manager;
    [SerializeField] private GameObject endGameCanvas;

    private List<float> timeTour;
    private float time;
    private float bestTime;
    private int bestTour;
    private void Start()
    {
        timeTour = new List<float>();
        timeTour.Clear();
        manager = FindObjectOfType<CheckpointManager>();
        endGameCanvas.SetActive(false);
        if (manager == null)
        {
            Debug.LogError("CheckpointManager introuvable dans la scène.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (manager.AreAllCheckpointsTrue())
            {
                round.AddTour();
                manager.ResetAllCheckpoints();
                timeTour.Add(time);
                
                round.UpdateTour();
                
                time = 0;
            }
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void BestTime()
    {
        print("coucou");
        bestTime = timeTour.Min();
        bestTour = timeTour.IndexOf(bestTime);
    }

    public int GetBestTour() { return bestTour; }

    public float GetBestTime() { return bestTime; }

}
