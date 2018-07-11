using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Transform target;
    public float speed;
    public bool facingRight;

    // Use this for initialization
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Pit").GetComponent<Transform>();
        if (!facingRight)
            Flip();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
