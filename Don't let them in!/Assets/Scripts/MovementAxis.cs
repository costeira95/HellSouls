using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAxis : MonoBehaviour {

    public bool pressed;
    public float direction;
	// Use this for initialization
	void Start () {
        pressed = false;
	}

    private void OnMouseDown()
    {
        pressed = true;
    }

    private void OnMouseUp()
    {
        pressed = false;
    }
}
