using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class End : MonoBehaviour
{
    [SerializeField] Round round;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            round.AddTour();
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(ReenableCollider(collision.gameObject)); 
        }
    }

    private IEnumerator ReenableCollider(GameObject player)
    { 
        yield return new WaitForSeconds(3f);
        player.GetComponent<Collider2D>().enabled = true;
    }
}
