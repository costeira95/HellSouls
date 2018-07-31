using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Transform target;
    public float speed;
    public bool facingRight; // Verifica se está a olhar para a direita
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
        //Move o inimigo para o pit
       transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    // Vira o personagem para o lado correto
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
