using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100; 
    public TextMeshProUGUI healthText;
    public Material material;
    public Color defaultColor;
    public float timer = 0;
    public CinemachineImpulseSource impulseSource;
    public Slider slider;


    private void Start()
    {
        material.SetColor("_BaseColor", Color.green);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        material.SetColor("_BaseColor", Color.red);
        timer = 1f;
        impulseSource.GenerateImpulseWithForce(1f);


        if (health <= 0)
        {
            health = 0;
        }
        //healthText.SetText("Health: " + health.ToString() + "/" + maxHealth.ToString());

        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOverMenu");
    }

    private void Update()
    {
        slider.value = (float)health / 100f;
        if (timer > 0f)
        {
            timer = timer - Time.deltaTime;
            Mathf.Clamp(timer, 0, timer);
        }
        if(timer <= 0f)
        {
            //print("hmm");
            material.SetColor("_BaseColor", Color.green);
        }
    }

}
