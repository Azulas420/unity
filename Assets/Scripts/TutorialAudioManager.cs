using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TutorialAudioManager : MonoBehaviour
{
    public AudioSource TMusic; // Referência ao componente AudioSource para a música do tutorial
    public AudioClip backgroundMusic; // Referência ao clipe de áudio da música de fundo

    void Start()
    {
        TMusic.clip = backgroundMusic; // Define o clipe de áudio da música de fundo para o componente AudioSource
        TMusic.Play(); // Toca a música de fundo
    }

    void Update()
    {
        // Nada a ser feito no Update() neste script
    }
}