using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    

    public void Quit()
    {
        Application.Quit();
    }

    public void RestartGameFromBeginning()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void RestartLVL3()
    {
        SceneManager.LoadScene("LVL3");
    }
}
