using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour {

    public float rotation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy_Boss"))
        {
            other.transform.Rotate(0, 0, rotation);
        }
    }
}
