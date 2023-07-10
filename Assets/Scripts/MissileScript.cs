using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // O código de inicialização pode ser adicionado aqui, se necessário
    }

    // Update is called once per frame
    void Update()
    {
        // O código de atualização pode ser adicionado aqui, se necessário
    }

    // Chamado quando ocorre uma colisão 2D com o objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); // Destroi o objeto do míssil quando colide com outro objeto
    }
}