using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public AudioSource FinishSound;
    public bool playerIsClose;

    // Start is called before the first frame update
    void Start()
    {
        FinishSound =  GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("CompleteLevel", 3f);
            playerIsClose = true;
            FinishSound.Play();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
