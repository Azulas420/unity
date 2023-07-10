using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TurorialNPC : MonoBehaviour
{
    public bool playerIsClose; // Indica se o jogador está próximo ou não
    public GameObject voicebtn; // Botão visual para interação com o NPC
    public AudioSource clip; // Referência ao componente AudioSource

    void Start()
    {
        voicebtn.SetActive(false); // Desativa o botão de voz no início
        clip = GetComponent<AudioSource>(); // Obtém o componente AudioSource do NPC
    }

    void Update()
    {
        // Verifica se o jogador pressionou a tecla F e está próximo do NPC
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            clip.Play(); // Toca o áudio associado ao NPC
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true; // Define o jogador como próximo
            voicebtn.SetActive(true); // Ativa o botão de voz
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false; // Define o jogador como distante
            voicebtn.SetActive(false); // Desativa o botão de voz
        }
    }
}