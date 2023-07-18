using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretLV1Script : MonoBehaviour
{
    public bool playerIsClose; // Indica se o jogador está próximo da torre
    public GameObject Weapon; // Referência ao objeto de arma da torre
    public GameObject Bullet; // Referência ao objeto de bala
    public float FireRate; // Taxa de disparo da torre
    float nextTimeToFire = 0; // Próximo tempo para disparar
    public float Range; // Alcance da torre
    public float Force; // Força do disparo
    public Transform ShootPoint; // Ponto de origem do disparo
    public Transform? Target; // Alvo da torre
    Vector2 Direction; // Direção para o alvo
   

    // Update is called once per frame
    void Update()
    {
        // Verifica se há um alvo
        if (Target != null)
        {
            Vector2 targetPos = Target.position;

            Direction = targetPos - (Vector2)transform.position;

            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

            // Verifica se o raio atingiu algo
            if (rayInfo)
            {
                if (rayInfo.collider.gameObject.tag == "Player")
                {
                    if (playerIsClose == false)
                    {
                        playerIsClose = true; // Define que o jogador está próximo
                    }
                }
                else
                {
                    if (playerIsClose == true)
                    {
                        playerIsClose = false; // Define que o jogador não está próximo
                    }
                }
            }
        }

        // Se o jogador estiver próximo e houver um alvo
        if (playerIsClose && Target != null)
        {
            Weapon.transform.up = Direction; // Ajusta a direção da arma para o alvo

            // Verifica se é possível disparar
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate; // Atualiza o próximo tempo para disparar
                shoot(); // Executa o disparo
            }
        }
    }

    // Função responsável por realizar o disparo
    void shoot()
    {
        Vector2 direction = (Vector2)Target.position - (Vector2)ShootPoint.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Instancia uma bala e adiciona uma força para impulsioná-la na direção correta
        GameObject shootInstance = Instantiate(Bullet, ShootPoint.position, rotation);
        shootInstance.GetComponent<Rigidbody2D>().AddForce(direction.normalized * Force);

        if (Target != null)
        {
            playerIsClose = false; // Define que o jogador não está próximo após o disparo
        }
    }

    // Desenha uma esfera para representar o alcance da torre no Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}