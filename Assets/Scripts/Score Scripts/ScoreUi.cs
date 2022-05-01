using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowui;
    public ScoreManager scoreManager;
    public Score score;

    int scoreboardLength;

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void UpdateHighScoreUI()
    {
        var scores = scoreManager.GetHighScores().ToArray();

        /*if(scores.Length >= 10)
        {
            scoreboardLength = 10;
        }
        else
        {
            scoreboardLength = scores.Length;
        }*/

        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowui, transform).GetComponent<RowUi>();
            row.Rank.text = (i + 1).ToString();
            row.Name.text = scores[i]._name;
            row.Score.text = scores[i].score.ToString();
        }
    }
}
