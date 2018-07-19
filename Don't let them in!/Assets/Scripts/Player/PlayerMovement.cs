using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    private bool isJumping = false;
    public GameObject player;
    private Rigidbody2D rb;

    private bool facingRight = true;
    int direction;
    public Transform spawnPoint;

    private bool isPressing = false;

    public int startExtraJumps;
    private int extraJumps;

    private bool spawnDust;
    public GameObject dustEffect;

    public Animator camAnim;
    private Animator playerAnim;

    private GroundCheck groundCheck;

    // Use this for initialization
    void Start () {
        rb = player.GetComponent<Rigidbody2D>();
        groundCheck = player.GetComponent<GroundCheck>();
        playerAnim = player.GetComponent<Animator>();
        extraJumps = startExtraJumps;
	}

    private void Update()
    {
        if (camAnim == null) camAnim = Camera.main.GetComponent<Animator>();

        if (!isJumping && !isPressing)
            direction = 0;

        playerAnim.SetInteger("walking", direction);
        if (groundCheck.IsOnTheGround())
        {
            if (spawnDust)
            {
                camAnim.SetTrigger("shake");
                Instantiate(dustEffect, groundCheck.Position(), Quaternion.identity);
                spawnDust = false;
            }
        }
        else
        {
            spawnDust = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (isPressing && direction == 1)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        } else if (isPressing && direction == -1)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }
        if (isJumping)
        {
            if(groundCheck.IsOnTheGround())
                Instantiate(dustEffect, groundCheck.Position(), Quaternion.identity);
            if (extraJumps == 0 && groundCheck.IsOnTheGround())
            {
                playerAnim.SetInteger("walking", 0);
                playerAnim.SetTrigger("jump");
                rb.velocity = Vector2.up * jumpSpeed;
                extraJumps = startExtraJumps;
                isJumping = false;
            }
            else if (extraJumps > 0)
            {
                playerAnim.SetInteger("walking", 0);
                playerAnim.SetTrigger("jump");
                rb.velocity = Vector2.up * jumpSpeed;
                extraJumps--;
                isJumping = false;
            }
            isJumping = false;
        }
	}

    public void MoveRight()
    {
        direction = 1;
        if (direction > 0 && !facingRight)
            Flip();
        isPressing = true;
    }

    public void MoveLeft()
    {
        direction = -1;
        if (direction < 0 && facingRight)
            Flip();
        isPressing = true;
    }

    public void Jump()
    {
        isJumping = true;
    }

    public void NotPressing()
    {
        isPressing = false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = player.transform.localScale;
        scaler.x *= -1;
        player.transform.localScale = scaler;

        Vector3 scalerSpawn = spawnPoint.localScale;
        scalerSpawn.x *= -1;
        spawnPoint.localScale = scalerSpawn;
    }
}
