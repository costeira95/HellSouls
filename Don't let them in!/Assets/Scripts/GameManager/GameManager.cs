using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /***************************************************
     * Criação de variáveis para o game manager
     */
    public static GameManager Instance = null;
    public GameObject[] charters;
    public bool isBossLevel = false;

    private int score; // score do jogo
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
        else
            Debug.Log("You dead!");
    }

    //Função para dar pontos ao personagem
    public void Score()
    {
        score++;
    }
}
