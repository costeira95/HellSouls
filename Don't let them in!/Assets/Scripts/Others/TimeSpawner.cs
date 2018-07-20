using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawner : MonoBehaviour {

    /*******************************************************
     * Criação das variaveis para o spawn,
     * spawnee é o que deve ser spawnado,
     * stopSpawning se quero que o spawn pare de spawnar,
     * canSpawn se pode spawnar e o spawn time que é o
     * tempo entre sapwns
     * ***************/
    public GameObject[] spawnee;
    private float spawnTime;
    public bool stopSpawning = false;
    private bool canSpawn = true;
    
    // Tempo minimo e máximo para o spawn aleatório
    public float MaxTimeSpawn;
    public float MinTimeSpawn;

    private void Update()
    {
        // Verifica se pode spawnar e se o stopSpawning está a falso
        if(canSpawn && !stopSpawning)
        {
            StartCoroutine(Spawn());
        }
    }

    // Cria um enumerador para spawnar de X em X tempo o spawnee e decide se pode ou não spawnar
    IEnumerator Spawn()
    {
        spawnTime = Random.Range(MinTimeSpawn, MaxTimeSpawn);
        Instantiate(spawnee[Random.Range(0, spawnee.Length - 1)], transform.position, Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }
}
