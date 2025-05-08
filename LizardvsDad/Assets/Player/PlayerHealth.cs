using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100; 
    public TextMeshProUGUI healthText;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
        }
        healthText.SetText("Health: " + health.ToString() + "/" + maxHealth.ToString());

        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOverMenu");
    }
}
