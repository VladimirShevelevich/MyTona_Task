using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioClip enemyExplosion;
    public AudioClip playerExplosion;
    public AudioClip hit;

    public static bool MUTE;

    AudioSource audioSource;

    public static SoundController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!MUTE)
            audioSource.Play();
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip sound)
    {
        if (!MUTE)
            audioSource.PlayOneShot(sound);
    }

    public void Mute()
    {
        if (!MUTE)
        {
            MUTE = true;
            audioSource.Stop();
        }
        else
        {
            MUTE = false;
            audioSource.Play();
        }
    }
}
