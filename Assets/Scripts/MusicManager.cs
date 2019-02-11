using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(float seconds)
    {
        if (audioSource.isPlaying) return;
        audioSource.PlayDelayed(seconds);
    }
}
