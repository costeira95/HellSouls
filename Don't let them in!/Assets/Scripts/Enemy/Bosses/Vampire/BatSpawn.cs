using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawn : MonoBehaviour {

    /* ***********************************************
     * Criação de variaveis para o spawn do morcego
     */
    public GameObject[] spawnPoints;
    public GameObject batPrefab;
    private bool canSpawn = true;
    public float spawnTime;

    // Update is called once per frame
    void Update () {
        // Verifica de pode spawnar um morcego
		if(canSpawn) 
        {
            StartCoroutine(Spawn());
        }
	}

    IEnumerator Spawn()
    {
        // Precorre a lista de spawn points instancia um morcego
        foreach (var spawn in spawnPoints)
        {
           Instantiate(batPrefab, spawn.transform.position, Quaternion.identity);
        }
        canSpawn = false;
        yield return new WaitForSeconds(spawnTime); // Espera x segfundos até ao proximo spawn
        canSpawn = true;
    }
}
