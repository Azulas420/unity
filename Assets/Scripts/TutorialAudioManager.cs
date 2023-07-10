using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TutorialAudioManager : MonoBehaviour
{
    public AudioSource TMusic; // Refer�ncia ao componente AudioSource para a m�sica do tutorial
    public AudioClip backgroundMusic; // Refer�ncia ao clipe de �udio da m�sica de fundo

    void Start()
    {
        TMusic.clip = backgroundMusic; // Define o clipe de �udio da m�sica de fundo para o componente AudioSource
        TMusic.Play(); // Toca a m�sica de fundo
    }

    void Update()
    {
        // Nada a ser feito no Update() neste script
    }
}