using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class End : MonoBehaviour
{
    [SerializeField] Round round;
    private CheckpointManager manager;

    private bool win = false;
    private List<float> timeTour;
    private float time;
    private int worldChoice;
    private void Start()
    {
        timeTour = new List<float>();
        manager = FindObjectOfType<CheckpointManager>();
        if (manager == null)
        {
            Debug.LogError("CheckpointManager introuvable dans la scène.");
        }
        worldChoice = PlayerPrefs.GetInt("WorldChoice", 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (float item in timeTour)
            {
                Debug.Log(item);
            }
            if (manager.AreAllCheckpointsTrue())
            {
                timeTour.Add(time);
                time = 0;
                round.AddTour();
                manager.ResetAllCheckpoints();
                if(worldChoice == 1)
                {
                    round.UpdateTour($"{round.GetTour()} / {round.GetTotalTour()}");
                }
                else
                {
                    round.UpdateTour($"{round.GetTour()}");
                }
                
            }
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public List<float> GetTours() { return timeTour; }

}
