using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    #region Private Variables

    bool isDead = false;
    float currentScore = 0;

    public ScoreManager scoreManager;
    public ScoreUi scoreUi;

    #endregion

    #region Serialize and Public Variables

    [Header("Health Components")]

    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject HighscorePanel;

    [Header("Player Health Settings")]

    public float currentHealth;
    public float maxHealth;

    #endregion

    #region In-Built Functions

    private void Start()
    {
        HighscorePanel.SetActive(false);
        //scoreUi.UpdateHighScoreUI();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
        CheckDeath();
        DebugScore();
    }

    void DebugScore()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            currentScore += 10;
        }
    }

    void CheckDeath()
    {
        if(!isDead && Input.GetKeyDown(KeyCode.Escape)) 
        {
            currentHealth = 0;
        }
        else if(isDead && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            
            HighscorePanel.SetActive(true);
            //scoreManager.AddScore(new Score("Bob", 100));
            scoreManager.AddScore(new Score(PlayerPrefs.GetString("name"), currentScore));
        }
        else if(isDead && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    #endregion
}
