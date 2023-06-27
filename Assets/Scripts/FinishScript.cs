using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
            playerIsClose = true;
            FinishSound.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {

    }
    
}
