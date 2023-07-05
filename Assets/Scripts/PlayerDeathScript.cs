using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{    
    public bool playerIsDead;
    public GameObject deathscreen;

    // Start is called before the first frame update
    void Start()
    {
        deathscreen.SetActive(false);
    }
 
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Bullet") && !playerIsDead)
        {
            playerIsDead = true;
            Destroy (col.gameObject);
            Destroy (gameObject);
            deathscreen.SetActive(true);
        }
    }  
}

