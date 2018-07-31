using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour {
    
    /**************************************************************
     * Variáveis para o vampiro, spawnPositions são os sitios onde
     * vai spawnar random, se está a mover, moveTime é o tempo
     * que fica parado, move é a posião onde se vai mover e 
     * o can move verifica se o personagem se pode mover
     */
    public GameObject[] spawnPositions;
    public bool isMoving = false;
    public float moveTime;
    private GameObject player;
    private int move;
    private bool canMove = false;

    public GameObject moveParticle;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        // se não estiver a mover começa a corrutina
		if(!isMoving)
        {
            StartCoroutine(Move());
        }
    }

    // Move o vampiro para uma posição aleatoria
    IEnumerator Move()
    {
        StartCoroutine(ChooseRandom());
        if (canMove)
        {
            Instantiate(moveParticle, transform.position, Quaternion.identity);
            transform.position = spawnPositions[move].transform.position;
            isMoving = true;
            yield return new WaitForSeconds(moveTime);
            isMoving = false;
            canMove = false;
        }
    }

    // Procura a melhor posição random e que não esteja perto do jogador
    IEnumerator ChooseRandom()
    {
        while (!canMove)
        {
            move = Random.Range(0, spawnPositions.Length - 1);
            if (Vector2.Distance(player.transform.position, spawnPositions[move].transform.position) < 2f)
                canMove = false;
            else
                canMove = true;
        }
        yield return null;
    }
}
