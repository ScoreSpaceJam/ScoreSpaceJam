using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    #region Private Variables
    #endregion

    #region Serialize and Public Variables

    [Header("Health Components")]

    [SerializeField] Image healthBarImage;

    [Header("Player Health Settings")]

    public float currentHealth;
    public float maxHealth;

    #endregion

    #region In-Built Functions

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    #endregion
}
