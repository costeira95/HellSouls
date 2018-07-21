using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour {

    public GameObject[] spawnPositions;
    public bool isMoving = false;
    public float moveTime;
    private GameObject player;
    private int move;
    private bool canMove = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(!isMoving)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        StartCoroutine(ChooseRandom());
        if (canMove)
        {
            transform.position = spawnPositions[move].transform.position;
            isMoving = true;
            yield return new WaitForSeconds(moveTime);
            isMoving = false;
            canMove = false;
        }
    }

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
