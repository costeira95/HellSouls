using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
            anim.SetTrigger("move");
    }
}
