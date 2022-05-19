using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    #region Private Variables

    float timer = 0;
    float timebase = 5;

    Animator anim;

    bool canShowHighScore = false;
    bool canRestart = false;

    bool isDead = false;
    public float currentScore = 0;

    public ScoreManager scoreManager;
    public ScoreUi scoreUi;

    #endregion

    #region Serialize and Public Variables

    [Header("Health Components")]

    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject HighscorePanel;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject SpawnerGameObject;

    [Header("Player Health Settings")]

    public float currentHealth;
    public float maxHealth;

    #endregion

    #region In-Built Functions

    private void Start()
    {
        anim = GetComponent<Animator>();

        Time.timeScale = 1;
        HighscorePanel.SetActive(false);
        //scoreUi.UpdateHighScoreUI();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
        CheckDeath();
       // DebugScore();

        score.text = currentScore.ToString();
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
            HighscorePanel.SetActive(true);
            scoreManager.AddScore(new Score(PlayerPrefs.GetString("name"), currentScore));
            currentHealth = 0;
            Time.timeScale = 0;
        }
        else if(isDead && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if(canShowHighScore)
        {
            timer += Time.deltaTime;
            if (timer > timebase)
            {
                Time.timeScale = 0;
                HighscorePanel.SetActive(true);
                scoreManager.AddScore(new Score(PlayerPrefs.GetString("name"), currentScore));
                canRestart = true;
                canShowHighScore = false;
            }
        }

        if(currentHealth <= 0 && !isDead)
        {
            anim.SetBool("IsDead", true);
            SpawnerGameObject.SetActive(false);

            canShowHighScore = true;

            isDead = true;

            /*isDead = true;
            Time.timeScale = 0;
            HighscorePanel.SetActive(true);
            scoreManager.AddScore(new Score(PlayerPrefs.GetString("name"), currentScore));*/
        }
        /*else if(isDead && Input.GetKeyDown(KeyCode.R) && !Input.GetKeyDown(KeyCode.Escape) && canShowHighScore)
        {
            SceneManager.LoadScene(1);
        }*/
        else if(isDead && Input.GetKeyDown(KeyCode.R) && canRestart)
        {
            SceneManager.LoadScene(1);
        }
    }

    #endregion
}
