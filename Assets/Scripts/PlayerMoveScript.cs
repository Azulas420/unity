using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private float horizontal; // Valor do movimento horizontal do jogador
    public float jumpStrenght; // Força do salto do jogador
    public float playerSpeed; // Velocidade de movimento do jogador

    [SerializeField] private Rigidbody2D rb; // Referência ao Rigidbody2D do jogador
    [SerializeField] private Transform groundCheck; // Referência ao objeto usado para verificar se o jogador está no chão
    [SerializeField] private LayerMask groundLayer; // Camada que representa o chão

    // Start is called before the first frame update
    void Start()
    {
        // Nada a ser feito no Start()
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Obtém o valor do movimento horizontal do jogador

        // Verifica se o jogador pressionou o botão de pulo e está no chão
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrenght); // Aplica uma força vertical para realizar o salto
        }

        // Verifica se o jogador soltou o botão de pulo e está subindo no salto
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
        // Verifica se há um objeto de chão abaixo do jogador usando um círculo de detecção
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
