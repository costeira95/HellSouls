using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

	// Use this for initialization
	void Awake () {
        Screen.orientation = ScreenOrientation.Landscape;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void LoseHealth()
    {
        if (GetComponent<Health>().health > 0)
            GetComponent<Health>().health--;
        else
            Debug.Log("You dead!");
    }
}
