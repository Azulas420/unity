using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class KillingColiderScript : MonoBehaviour
{
 
    public GameObject Player;
    public AudioSource clip;
    public GameObject PlayerDeathEffect;
    public GameObject deathscreen;

    void Start()
    {
        clip = GetComponent<AudioSource>();
        deathscreen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Player != null && other.CompareTag("Player"))
        {
            Destroy(Player);
            Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);
            deathscreen.SetActive(true);
            if (clip != null)
            {
                clip.Play();
            }   
        }
    }
}
