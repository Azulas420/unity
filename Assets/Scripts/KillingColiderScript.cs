using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class KillingColiderScript : MonoBehaviour
{
    public GameObject Player; // Referência ao objeto do jogador
    public AudioSource clip; // Componente AudioSource para reprodução de som
    public GameObject PlayerDeathEffect; // Efeito de morte do jogador
    public GameObject deathscreen; // Tela de morte

    void Start()
    {
        clip = GetComponent<AudioSource>(); // Obtém o componente AudioSource do objeto
        deathscreen.SetActive(false); // Desativa a tela de morte no início
    }

    // Chamado quando ocorre uma colisão 2D com o objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Player != null && other.CompareTag("Player")) // Verifica se o objeto do jogador não é nulo e se a tag do objeto colidido é "Player"
        {
            Destroy(Player); // Destroi o objeto do jogador
            Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity); // Instancia o efeito de morte do jogador na posição do objeto atual
            deathscreen.SetActive(true); // Ativa a tela de morte
            if (clip != null)
            {
                clip.Play(); // Reproduz o som associado ao componente AudioSource
            }
        }
    }
}