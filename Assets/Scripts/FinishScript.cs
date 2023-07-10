using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public AudioSource FinishSound; // Componente AudioSource para o som de finalização
    public bool playerIsClose; // Indica se o jogador está próximo

    // Start is called before the first frame update
    void Start()
    {
        FinishSound = GetComponent<AudioSource>(); // Obtém o componente AudioSource do objeto
    }

    // Chamado quando ocorre uma colisão 2D com o objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se a tag do objeto colidido é "Player"
        {
            Invoke("CompleteLevel", 3f); // Invoca o método CompleteLevel() após 3 segundos
            playerIsClose = true; // Define que o jogador está próximo
            FinishSound.Play(); // Reproduz o som de finalização
        }
    }

    // Método para completar o nível
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carrega a próxima cena na ordem de build
    }
}