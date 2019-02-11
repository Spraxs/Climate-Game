using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> audioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWaterShoot()
    {
        if (audioSource.isPlaying) return;

        audioSource.clip = audioClips[0];

        audioSource.Play();
    }
}
