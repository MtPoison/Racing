using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] List<Checkpoint> checkpoints;
    private int lastCheckpointIndex = -1;


    public void ActivateCheckpoint(int checkpointIndex, Checkpoint checkpoint)
    {
        if (checkpointIndex < 0 || checkpointIndex >= checkpoints.Count)
        {
            Debug.LogError("Index de checkpoint invalide !");
            return;
        }

        if (checkpointIndex == lastCheckpointIndex + 1)
        {
            checkpoint.Activate();
            lastCheckpointIndex = checkpointIndex;
        }
        else if (checkpointIndex <= lastCheckpointIndex)
        {
            Debug.Log("Contre-sens d�tect� : vous �tes retourn� dans un checkpoint d�j� franchi !");
        }
        else
        {
            Debug.Log($"Checkpoint {checkpointIndex} ignor� : vous avez saut� un checkpoint !");
        }
    }

    public bool AreAllCheckpointsTrue()
    {
        foreach (var checkpoint in checkpoints)
        {
            if (!checkpoint.IsPass()) return false;
        }
        return true;
    }

    public void ResetAllCheckpoints()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.FalsePass();
        }
        lastCheckpointIndex = -1;
        Debug.Log("Tous les checkpoints ont �t� r�initialis�s.");
    }
}
