using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {

    /************************************************************
     * Variaveis para a força, ponto de spwan, os niveis de bosses
     * para escolher aleatoriamente e o efeito de hit
     */
    public float force;
    private Rigidbody2D rb;
    private Transform spawnPoint;
    public string[] bossesLevel;
    public GameObject hitEffect;
    public float damage;

    // Use this for initialization
    void Awake () {
        /** 
         * Verifica se é um boss, se for então a bala passa a ser triggered em vez de colider,
         * deois acha o spawn point e verifica se o spwanpoint estiver á direita então aplica força
         * á direita se não aplica força á direita da bala
         */
        if (GameManager.Instance.isBossLevel)
            GetComponent<CircleCollider2D>().isTrigger = true;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (spawnPoint.localScale.x > 0)
            rb.AddForce(Vector2.right * force);
        else if (spawnPoint.localScale.x < 0)
            rb.AddForce(Vector2.left * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        /**************************************************************
         * Verifica se colidiu com um inimigo(vermelhas), ou se colidiu
         * com um inimigo que leva ao boss(amarelas), se colidiu com um
         * inimigo de boss vai para um boss aleatoriamente
         */
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            GameManager.Instance.Score();
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else if(other.gameObject.CompareTag("Enemy_Boss"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            GameManager.Instance.Score();
            GameManager.Instance.isBossLevel = true;
            SceneManager.LoadScene(bossesLevel[Random.Range(0, bossesLevel.Length-1)]);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se acertou no boss e tira dano
        if (other.gameObject.CompareTag("Boss"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            other.gameObject.GetComponent<Boss>().TakeDamage(damage);
        }
    }
}
