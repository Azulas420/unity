using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // O c�digo de inicializa��o pode ser adicionado aqui, se necess�rio
    }

    // Update is called once per frame
    void Update()
    {
        // O c�digo de atualiza��o pode ser adicionado aqui, se necess�rio
    }

    // Chamado quando ocorre uma colis�o 2D com o objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); // Destroi o objeto do m�ssil quando colide com outro objeto
    }
}