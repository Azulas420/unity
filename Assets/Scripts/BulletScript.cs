using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    // OnCollisionEnter2D � chamado quando ocorre uma colis�o 2D com outro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); // Destroi o objeto da bala que colidiu com outro objeto
    }

}