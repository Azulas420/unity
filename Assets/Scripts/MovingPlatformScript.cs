using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speed; // Velocidade da plataforma em unidades por segundo
    public int startingPoint; // Índice do ponto inicial da plataforma
    public Transform[] points; // Lista de transformações que representam os pontos para onde a plataforma se moverá

    private int i; // Índice atual do ponto

    // Start is called before the first frame update
    void Start()
    {
        // Define a posição inicial da plataforma como a posição do ponto de partida
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se a plataforma chegou perto o suficiente do ponto atual
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; // Avança para o próximo ponto
            if (i == points.Length)
            {
                i = 0; // Reinicia o índice quando atinge o final da lista de pontos
            }
        }

        // Move a plataforma em direção ao ponto atual com uma velocidade suave
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    // Chamado quando ocorre uma colisão 2D com a plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform); // Define o objeto colidido como filho da plataforma
    }

    // Chamado quando um objeto sai da colisão 2D com a plataforma
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null); // Remove o objeto colidido como filho da plataforma
    }
}