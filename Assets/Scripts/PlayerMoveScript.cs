using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private float horizontal; // Valor do movimento horizontal do jogador
    public float jumpStrenght; // For�a do salto do jogador
    public float playerSpeed; // Velocidade de movimento do jogador

    [SerializeField] private Rigidbody2D rb; // Refer�ncia ao Rigidbody2D do jogador
    [SerializeField] private Transform groundCheck; // Refer�ncia ao objeto usado para verificar se o jogador est� no ch�o
    [SerializeField] private LayerMask groundLayer; // Camada que representa o ch�o

    // Start is called before the first frame update
    void Start()
    {
        // Nada a ser feito no Start()
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Obt�m o valor do movimento horizontal do jogador

        // Verifica se o jogador pressionou o bot�o de pulo e est� no ch�o
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrenght); // Aplica uma for�a vertical para realizar o salto
        }

        // Verifica se o jogador soltou o bot�o de pulo e est� subindo no salto
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // Reduz a velocidade vertical para um pulo mais curto
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y); // Aplica a velocidade horizontal ao jogador
    }

    private bool IsGrounded()
    {
        // Verifica se h� um objeto de ch�o abaixo do jogador usando um c�rculo de detec��o
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
