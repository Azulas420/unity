using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TutorialAudioManager : MonoBehaviour
{
    public AudioSource TMusic;

    public AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
       TMusic.clip = backgroundMusic;
       TMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
