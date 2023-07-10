using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TurorialNPC : MonoBehaviour
{
    public bool playerIsClose; // Indica se o jogador est� pr�ximo ou n�o
    public GameObject voicebtn; // Bot�o visual para intera��o com o NPC
    public AudioSource clip; // Refer�ncia ao componente AudioSource

    void Start()
    {
        voicebtn.SetActive(false); // Desativa o bot�o de voz no in�cio
        clip = GetComponent<AudioSource>(); // Obt�m o componente AudioSource do NPC
    }

    void Update()
    {
        // Verifica se o jogador pressionou a tecla F e est� pr�ximo do NPC
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            clip.Play(); // Toca o �udio associado ao NPC
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true; // Define o jogador como pr�ximo
            voicebtn.SetActive(true); // Ativa o bot�o de voz
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false; // Define o jogador como distante
            voicebtn.SetActive(false); // Desativa o bot�o de voz
        }
    }
}