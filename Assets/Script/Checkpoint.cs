using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int checkpointIndex;
    private bool pass;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pass = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var manager = FindObjectOfType<CheckpointManager>();
            if (manager != null)
            {
                manager.ActivateCheckpoint(checkpointIndex, this);
                spriteRenderer.color = Color.green;

            }
        }
    }

    public bool IsPass() { return pass; }

    public void FalsePass() { pass = false; }

    public void Activate() { pass = true; }
}
