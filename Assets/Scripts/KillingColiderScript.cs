using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class KillingColiderScript : MonoBehaviour
{

    bool PlayerIsAlive = true;
    public GameObject Player;
    public AudioSource clip;

    void Start()
    {
        clip = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Player != null && other.CompareTag("Player"))
        {
            PlayerIsAlive = false;
            Destroy(Player);
            if (clip != null)
            {
                clip.Play();
            }
          

        }
    }


}
