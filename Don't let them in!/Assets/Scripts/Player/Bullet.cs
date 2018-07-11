using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float force;
    private Rigidbody2D rb;
    private Transform spawnPoint;

	// Use this for initialization
	void Awake () {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (spawnPoint.localScale.x > 0)
            rb.AddForce(Vector2.right * force);
        else if (spawnPoint.localScale.x < 0)
            rb.AddForce(Vector2.left * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
