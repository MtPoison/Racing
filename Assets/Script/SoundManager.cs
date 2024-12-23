using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Aucun AudioSource trouv� sur " + gameObject.name);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopSound()
    {
        if (audioSource == null) return;

        audioSource.Stop();
    }

    public void PlaySoundIfNotPlaying(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;

        if (audioSource.clip != clip || !audioSource.isPlaying)
        {
            PlaySound(clip);
        }
    }

    public void AdjustVolume(float normalizedValue)
    {
        if (audioSource == null) return;

        audioSource.volume = Mathf.Clamp01(normalizedValue);
    }
}
