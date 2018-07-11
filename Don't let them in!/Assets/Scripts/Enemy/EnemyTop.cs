using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour {

    public bool movingRight;
    private Transform target;
    public float speed;

    private bool firstFlip = true;
    private bool firstGroundTuch = false;

    private GroundCheck groundCheck;

    // Use this for initialization
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Pit").GetComponent<Transform>();
        if (!movingRight)
            Flip();
    }

    private void Start()
    {
        groundCheck = GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!groundCheck.IsOnTheGround() && !firstGroundTuch)
        {
            if (movingRight)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            else if (!movingRight)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        } else if (!groundCheck.IsOnTheGround() && firstGroundTuch)
        {
            if (movingRight)
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            else if (!movingRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else if (groundCheck.IsOnTheGround())
        {
            if (firstFlip)
            {
                Flip();
                firstFlip = !firstFlip;
                firstGroundTuch = !firstGroundTuch;
            }
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pit"))
        {
            Destroy(gameObject);
        }
    }

}
