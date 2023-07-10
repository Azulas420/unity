using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretLV3Script : MonoBehaviour
{
    public bool playerIsClose; // Indica se o jogador est� pr�ximo da torre
    public GameObject Weapon; // Refer�ncia ao objeto de arma da torre
    public GameObject Bullet; // Refer�ncia ao objeto de bala
    public float FireRate; // Taxa de disparo da torre
    float nextTimeToFire = 0; // Pr�ximo tempo para disparar
    public float Range; // Alcance da torre
    public float Force; // For�a do disparo
    public Transform ShootPoint; // Ponto de origem do primeiro disparo
    public Transform ShootPoint2; // Ponto de origem do segundo disparo
    public Transform ShootPoint3; // Ponto de origem do terceiro disparo
    public Transform? Target; // Alvo da torre
    Vector2 Direction; // Dire��o para o alvo

    // Start is called before the first frame update
    void Start()
    {
        // O c�digo de inicializa��o pode ser adicionado aqui, se necess�rio
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se h� um alvo
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
                        playerIsClose = true; // Define que o jogador est� pr�ximo
                    }
                }
                else
                {
                    if (playerIsClose == true)
                    {
                        playerIsClose = false; // Define que o jogador n�o est� pr�ximo
                    }
                }
            }
        }

        // Se o jogador estiver pr�ximo e houver um alvo
        if (playerIsClose && Target != null)
        {
            Weapon.transform.up = Direction; // Ajusta a dire��o da arma para o alvo

            // Verifica se � poss�vel disparar
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate; // Atualiza o pr�ximo tempo para disparar
                shoot(); // Executa o disparo
            }
        }
    }

    // Fun��o respons�vel por realizar o disparo
    void shoot()
    {
        Vector2 direction = (Vector2)Target.position - (Vector2)ShootPoint.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Instancia tr�s balas e adiciona uma for�a para impulsion�-las na dire��o correta
        GameObject shootInstance = Instantiate(Bullet, ShootPoint.position, rotation);
        shootInstance.GetComponent<Rigidbody2D>().AddForce(direction.normalized * Force);

        GameObject shootInstance2 = Instantiate(Bullet, ShootPoint2.position, rotation);
        shootInstance2.GetComponent<Rigidbody2D>().AddForce(direction.normalized * Force);

        GameObject shootInstance3 = Instantiate(Bullet, ShootPoint3.position, rotation);
        shootInstance3.GetComponent<Rigidbody2D>().AddForce(direction.normalized * Force);

        if (Target != null)
        {
            playerIsClose = false; // Define que o jogador n�o est� pr�ximo ap�s o disparo
        }
    }

    // Desenha uma esfera para representar o alcance da torre no Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}