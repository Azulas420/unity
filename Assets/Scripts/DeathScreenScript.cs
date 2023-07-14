using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{

    // Reinicia o jogo
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Carrega novamente a cena atual
    }

    // Sai do jogo
    public void Quit()
    {
        Application.Quit(); // Encerra a aplicação
    }
}