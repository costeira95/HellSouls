using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int health;

    public Image hearth;
    public Sprite fullHearth;
    public Sprite minusOneHearth;
    public Sprite minusTwoHearths;
    public Sprite emptyHearth;

	// Update is called once per frame
	void Update () {
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
