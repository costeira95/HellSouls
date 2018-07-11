using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransport : MonoBehaviour {

    public GameObject destination;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(destination != null)
                other.transform.position = destination.transform.Find("spawnPoint").position;
            else
                other.transform.position = transform.Find("spawnPoint").position;
        }
    }
}
