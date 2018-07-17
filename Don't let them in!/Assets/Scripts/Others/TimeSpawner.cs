using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawner : MonoBehaviour {

    public GameObject[] spawnee;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
	}
	
    void Spawn()
    {
        if (stopSpawning) {
            CancelInvoke("Spawn");
        }
        Instantiate(spawnee[Random.Range(0, spawnee.Length-1)], transform.position, Quaternion.identity);
    }
}
