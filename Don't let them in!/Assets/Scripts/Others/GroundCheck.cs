using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    /**************************************
     * Variáveis para verificar se o objecto
     * está a tocar no chão
     */
    private bool isGrounded;
    public LayerMask WhatIsGround;
    public Transform groundCheck;
    public float groundCheckRadious;

    private void FixedUpdate()
    {
        // Verifica se o objecto está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, WhatIsGround);
    }

    /***************************************
     * Função para retornar se está no chão 
     */
    public bool IsOnTheGround()
    {
        return isGrounded;
    }

    /******************************************
     * Retorna a posicao do chao
     */
    public Vector3 Position()
    {
        return groundCheck.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadious);
    }
}
