using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] List<Checkpoint> checkpoints;
    [SerializeField] private TMP_Text Etat;
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
            Etat.text = $"";
        }
        else if (checkpointIndex <= lastCheckpointIndex)
        {
            Etat.text = "Contre-sens détecté : vous êtes retourné dans un checkpoint déjà franchi !";
        }
        else
        {
            Etat.text = $"Checkpoint {checkpointIndex} ignoré : vous avez sauté un checkpoint !";
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
        Debug.Log("Tous les checkpoints ont été réinitialisés.");
    }
}
