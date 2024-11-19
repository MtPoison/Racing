using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class End : MonoBehaviour
{
    [SerializeField] Round round;
    private CheckpointManager manager;
    private void Start()
    {
        manager = FindObjectOfType<CheckpointManager>();
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
            }
        }
    }

}
