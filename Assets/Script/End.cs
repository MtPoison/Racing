using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.AddTour();
            if(gameManager.GetTour() == 3)
            {
                Debug.Log("Win");
            }
        }
    }
}
