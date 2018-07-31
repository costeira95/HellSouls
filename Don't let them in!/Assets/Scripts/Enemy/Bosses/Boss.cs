using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

    public float Health;
    public GameObject LifeUi;

    private void Update()
    {

        if (LifeUi.transform.localScale.x > 0)
        {
            var scaler = LifeUi.transform.localScale;
            scaler.x = Health / 100;
            LifeUi.transform.localScale = scaler;
        }

        if (Health <= 0)
        {
            GameManager.Instance.isBossLevel = false;
            SceneManager.LoadScene("level1");
        }
    }

    //função para tirar vida ao vampiro
    public void TakeDamage(float amount)
    {
        if (Health > 0)
            Health -= amount;
    }
}
