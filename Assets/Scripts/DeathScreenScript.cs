using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // O c�digo de inicializa��o pode ser adicionado aqui, se necess�rio
    }

    // Update is called once per frame
    void Update()
    {
        // O c�digo de atualiza��o pode ser adicionado aqui, se necess�rio
    }

    // Reinicia o jogo
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Carrega novamente a cena atual
    }

    // Sai do jogo
    public void Quit()
    {
        Application.Quit(); // Encerra a aplica��o
    }
}