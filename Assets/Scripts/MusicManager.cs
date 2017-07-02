using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : Singleton<MusicManager> {

    private AudioSource audioSource; 

	// Use this for initialization
	void Awake () {
        audioSource = GetComponent<AudioSource>();
	}
	
	
    public void PlayMusic(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
