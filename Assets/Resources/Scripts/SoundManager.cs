using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SoundManager Singleton
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    public AudioClip BallShoot;
    public AudioClip Explosion;

    public static SoundManager Instance;

    private AudioSource audioSource;

	// Use this for initialization
	void Awake () { 
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
	}

    public void PlayOneShot(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }
	
}
