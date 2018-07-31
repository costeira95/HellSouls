using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    // Define a vida jogador tem
    public int health;

    public Image hearth; // imagem onde vai ser mudado o sprite no canvas
    public Sprite fullHearth; // vida cheia
    public Sprite minusOneHearth; // vida com 2 corações
    public Sprite minusTwoHearths; // vida com 1 coração
    public Sprite emptyHearth; // vida vazia

	// Update is called once per frame
	void Update () {
        // Verifica a vida que o player tem e modifica o sprite consoante com a vida que o jogador tem
        switch (health) {
            case 3:
                hearth.sprite = fullHearth;
                break;
            case 2:
                hearth.sprite = minusOneHearth;
                break;
            case 1:
                hearth.sprite = minusTwoHearths;
                break;
            default:
                hearth.sprite = emptyHearth;
                break;
        }
        
	}
}
