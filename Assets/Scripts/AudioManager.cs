using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource Music; // O AudioSource � respons�vel pela reprodu��o de �udio
    public AudioClip backgroundMusic; // A musica de funda a ser reproduzida

    public static AudioManager instance; // Refer�ncia est�tica para a inst�ncia do AudioManager

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Define a inst�ncia atual do AudioManager
            DontDestroyOnLoad(gameObject); // Evita que o objeto seja destru�do ao carregar uma nova cena
        }
        else
        {
            Destroy(gameObject); // Se j� existe uma inst�ncia, destr�i o objeto atual
        }
    }

    
    void Start()
    {
        Music.clip = backgroundMusic; // Atribui a musica de fundo ao componente AudioSource
        Music.Play(); // Reproduz a musica
    }

   
    void Update()
    {
        // Verifica se a cena ativa tem o nome "EndGame"
        if (SceneManager.GetActiveScene().name == "EndGame")
            Music.GetComponent<AudioSource>().Pause(); // Pausa a reprodu��o do �udio
    }
}
