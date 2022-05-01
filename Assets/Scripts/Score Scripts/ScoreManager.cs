using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    public ScoreUi scoreUi;

    private void Awake() 
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
        
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
        sd.scores = sd.scores.OrderByDescending(x => x.score).ToList();
        if(sd.scores.Count > 10)   
        {
            sd.scores.RemoveAt(sd.scores.Count - 1);
        }
        scoreUi.UpdateHighScoreUI();
    }

    public void ClearScore()
    {
        sd.scores.Clear();
    }

    public void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
}
