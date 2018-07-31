using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    /***************************************************
     * Criação de variáveis para o game manager
     */
    public static GameManager Instance = null;
    public GameObject[] charters;
    public bool isBossLevel = false;
    private int score;
    public  GameObject[] spawners;
    // UI do jogo
    public GameObject scoreUI;
    public GameObject gameOverUI;
    
    // Use this for initialization
    void Awake () {
        Screen.orientation = ScreenOrientation.Landscape;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Verifica se o personagem foi comprado e selecionado para jogar
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

    //Função para o personagem perder vida
    public void LoseHealth()
    {
        if (GetComponent<Health>().health > 0)
            GetComponent<Health>().health--;
        if(GetComponent<Health>().health <= 0)
        {
            gameOverUI.SetActive(true);
            foreach (var s in spawners)
            {
                s.GetComponent<TimeSpawner>().stopSpawning = true;
            }
        }
            
    }

    //Função para dar pontos ao personagem
    public void Score()
    {
        score++;
        scoreUI.GetComponent<Text>().text = score.ToString();
    }
}
