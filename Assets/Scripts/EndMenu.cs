using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    // Sai do jogo
    public void Quit()
    {
        Application.Quit(); // Encerra a aplicação
    }

    // Reinicia o jogo a partir da tela inicial
    public void RestartGameFromBeginning()
    {
        SceneManager.LoadScene("StartScreen"); // Carrega a cena "StartScreen" para reiniciar o jogo
    }

    // Reinicia o nível 3 do jogo
    public void RestartLVL3()
    {
        SceneManager.LoadScene("LVL3"); // Carrega a cena "LVL3" para reiniciar o nível 3
    }
}