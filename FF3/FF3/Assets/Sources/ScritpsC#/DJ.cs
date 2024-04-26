using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ : MonoBehaviour
{
    private AudioSource _audioSource;
    public static DJ Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audio) 
    {
        _audioSource.PlayOneShot(audio);
    }
}
