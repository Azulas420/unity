using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public AudioSource FinishSound; // Componente AudioSource para o som de finaliza��o
    public bool playerIsClose; // Indica se o jogador est� pr�ximo

    // Start is called before the first frame update
    void Start()
    {
        FinishSound = GetComponent<AudioSource>(); // Obt�m o componente AudioSource do objeto
    }

    // Chamado quando ocorre uma colis�o 2D com o objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se a tag do objeto colidido � "Player"
        {
            Invoke("CompleteLevel", 3f); // Invoca o m�todo CompleteLevel() ap�s 3 segundos
            playerIsClose = true; // Define que o jogador est� pr�ximo
            FinishSound.Play(); // Reproduz o som de finaliza��o
        }
    }

    // M�todo para completar o n�vel
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carrega a pr�xima cena na ordem de build
    }
}