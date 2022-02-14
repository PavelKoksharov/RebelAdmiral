using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;

    public int maxHealth;
    public int curHealth;

    public HealthScript healthBar;

    void Start()
    {
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }

    public void PlayerHeal(int heal)
    {
        int actualHeal = heal * curHealth / 100;

        if (actualHeal + curHealth <= maxHealth)
        {
            curHealth += actualHeal;
            healthBar.SetHealth(curHealth);
        }

        else
        {
            curHealth = maxHealth;
            healthBar.SetHealth(curHealth);
        }
    }
}
