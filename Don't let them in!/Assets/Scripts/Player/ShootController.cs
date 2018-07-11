using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    private Vector3 spawnPoint;
    public GameObject bulletPrefab;
    public Transform SpawnPosition;
    public float startShootRate;
    private bool allowedToShoot = true;

    public GameObject Player;
    private Animator shootAnim;

    private void Start()
    {
        shootAnim = Player.GetComponent<Animator>();
    }

    public void Fire()
    {
        if (allowedToShoot)
        {
            shootAnim.SetTrigger("shoot");
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if (Player.transform.localScale.x < 0)
        {
            Instantiate(bulletPrefab, SpawnPosition.position, Quaternion.Euler(new Vector3(0, 180, 0)));
        }
        else
            Instantiate(bulletPrefab, SpawnPosition.position, Quaternion.Euler(new Vector3(180, 180, 180)));

        allowedToShoot = false;
        yield return new WaitForSeconds(startShootRate);
        allowedToShoot = true;
    }
}


