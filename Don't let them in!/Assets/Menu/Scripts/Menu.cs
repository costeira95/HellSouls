using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }
}
