using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public bool playerIsDead; // Variável que indica se o jogador está morto ou não
    public GameObject deathscreen; // Referência ao objeto da tela de morte

    // Start is called before the first frame update
    void Start()
    {
        deathscreen.SetActive(false); // Desativa a tela de morte no início do jogo
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Verifica se ocorreu uma colisão com um objeto que tenha a tag "Bullet" e se o jogador ainda não está morto
        if (col.gameObject.tag.Equals("Bullet") && !playerIsDead)
        {
            playerIsDead = true; // Define o jogador como morto
            Destroy(col.gameObject); // Destroi a bala que colidiu com o jogador
            Destroy(gameObject); // Destroi o objeto do jogador
            deathscreen.SetActive(true); // Ativa a tela de morte
        }
    }
}