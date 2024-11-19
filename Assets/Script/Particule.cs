using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour
{
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private float particleDuration = 2f;

    public void Start()
    {
        particleSystem.Stop();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ActivateParticles());
        }
    }

    private IEnumerator ActivateParticles()
    {
        particleSystem.Play();
        yield return new WaitForSeconds(particleDuration);
        particleSystem.Stop();
    }
}
