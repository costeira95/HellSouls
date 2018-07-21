using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class HighScores
{
    public Score[] scores;

    public HighScores()
    {
        scores = new Score[0];
    }
}

[Serializable]
public class Score : IComparable<Score>
{
    public int score;
    public Score(int score)
    {
        this.score = score;
    }
    public int CompareTo(Score obj)
    {
        if (score < obj.score)
            return -1;
        else if (score == obj.score)
            return 0;
        return 1;
    }
}

public class Menu : MonoBehaviour {

    Score score;
    HighScores highScores;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }

    public HighScores RetriveHighScores()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            string json = PlayerPrefs.GetString("HighScore");
            return JsonUtility.FromJson<HighScores>(json);
        }
        return new HighScores();
    }

    public void StoreHighScores()
    {
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("HighScore", json);
    }
}
