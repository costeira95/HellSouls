using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    public GameObject[] charters;
    
	// Use this for initialization
	void Awake () {
        Screen.orientation = ScreenOrientation.Landscape;
        Camera.main.aspect = 18f / 9f;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (var c in charters)
        {
            var player = c.GetComponent<Player>();
            if (player.wasBought && player.isSelected)
            {
                Debug.Log("Teste" + player.price);
            }
        }
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
