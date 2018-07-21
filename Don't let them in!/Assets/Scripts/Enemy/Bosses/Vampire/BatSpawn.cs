using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawn : MonoBehaviour {

    /* ***********************************************
     * Criação de variaveis para o spawn do morcego
     */
    public GameObject batPrefab;
    private bool canSpawn = true;
    public float spawnTime;
    private bool isMoving;

    // Update is called once per frame
    void Update () {
        // Verifica de pode spawnar um morcego
        isMoving = transform.parent.GetComponent<Vampire>().isMoving;

        if (canSpawn) 
        {
            StartCoroutine(Spawn());
        }
	}

    IEnumerator Spawn()
    {
        // instancia um morcego
        if (isMoving)
        {
            //yield return new WaitUntil(() => isMoving == true);
            Instantiate(batPrefab, transform.position, Quaternion.identity);
            canSpawn = false;
            yield return new WaitForSeconds(spawnTime); // Espera x segfundos até ao proximo spawn
            canSpawn = true;
        }
    }
}
