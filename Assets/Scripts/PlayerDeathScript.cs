using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{    
    public bool playerIsDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }  
        void OnCollisionEnter2D (Collision2D col)
        {
            if (col.gameObject.tag.Equals ("Bullet") && !playerIsDead)
            {
                playerIsDead = true;
                Destroy (col.gameObject);
                Destroy (gameObject);
            }
        }
    
}

