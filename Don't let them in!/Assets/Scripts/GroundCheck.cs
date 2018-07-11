using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private bool isGrounded;
    public LayerMask WhatIsGround;
    public Transform groundCheck;
    public float groundCheckRadious;

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, WhatIsGround);
    }

    public bool IsOnTheGround()
    {
        return isGrounded;
    }

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
