using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour {

    public float defaultWidth = 1920f;
    public float defaultHeight = 1080f;
    private float MAXSIZE = 2960;

    // Use this for initialization
    void Start()
    {
        var scaler = transform.localScale;
        if (MAXSIZE != Screen.width) {
            scaler.x = Screen.width / defaultWidth;
            scaler.y = Screen.height / defaultHeight;
            transform.localScale = scaler;
        } else if(MAXSIZE >= Screen.width)
        {
            scaler.x = 1.17f;
            transform.localScale = scaler;
        }
    }
}
