using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource Music; // O AudioSource é responsável pela reprodução de áudio
    public AudioClip backgroundMusic; // A musica de funda a ser reproduzida

    public static AudioManager instance; // Referência estática para a instância do AudioManager

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Define a instância atual do AudioManager
            DontDestroyOnLoad(gameObject); // Evita que o objeto seja destruído ao carregar uma nova cena
        }
        else
        {
            Destroy(gameObject); // Se já existe uma instância, destrói o objeto atual
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
            Music.GetComponent<AudioSource>().Pause(); // Pausa a reprodução do áudio
    }
}
