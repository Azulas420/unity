using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TurorialNPC : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject voicebtn;
    public AudioSource clip;
    
    

    // Update is called once per frame
    void Start()
        {
            voicebtn.SetActive(false);
            clip = GetComponent<AudioSource>();
            
        }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            clip.Play(); 
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            voicebtn.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            voicebtn.SetActive(false);
            //clip.Stop();
        }
    }
}
