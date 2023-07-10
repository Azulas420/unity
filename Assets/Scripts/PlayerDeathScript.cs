using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public bool playerIsDead; // Vari�vel que indica se o jogador est� morto ou n�o
    public GameObject deathscreen; // Refer�ncia ao objeto da tela de morte

    // Start is called before the first frame update
    void Start()
    {
        deathscreen.SetActive(false); // Desativa a tela de morte no in�cio do jogo
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Verifica se ocorreu uma colis�o com um objeto que tenha a tag "Bullet" e se o jogador ainda n�o est� morto
        if (col.gameObject.tag.Equals("Bullet") && !playerIsDead)
        {
            playerIsDead = true; // Define o jogador como morto
            Destroy(col.gameObject); // Destroi a bala que colidiu com o jogador
            Destroy(gameObject); // Destroi o objeto do jogador
            deathscreen.SetActive(true); // Ativa a tela de morte
        }
    }
}