using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //public Text healthText;

    private bool isDead = false;
    private SpriteRenderer sr;
    public Color hitColor = Color.red;
    public float flashDuration = .1f;
    private Color originalColor;

    void Awake()
    {
        currentHealth = 30;
        isDead = false;
        //UpdateHealthUI();

        sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            originalColor = sr.color;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth = Mathf.Max(0, currentHealth - amount);
        //UpdateHealthUI();
        if (sr != null)
        {
            StartCoroutine(FlashRed());
        }
        if (currentHealth <= 0)
            {
                Die();
            }
    }

    //void UpdateHealthUI()
    //{
    //    healthText.text = "Health: " + currentHealth;
    //}

    IEnumerator FlashRed()
    {
        sr.color = hitColor;
        yield return new WaitForSeconds(flashDuration);
        sr.color = originalColor;
    }

    void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;

        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

}
