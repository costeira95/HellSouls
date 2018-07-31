using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawn : MonoBehaviour {

    /* ***********************************************
     * Criação de variaveis para o spawn do morcego
     */
    public GameObject batPrefab;
    public GameObject boss;
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
            Instantiate(batPrefab, transform.position, Quaternion.identity);
            boss.GetComponent<Animator>().SetTrigger("attack");
            canSpawn = false;
            yield return new WaitForSeconds(spawnTime); // Espera x segfundos até ao proximo spawn
            canSpawn = true;
        }
    }
}
