using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject enemyShip;
    public string shipType;
    public GameObject expEffect;
    public string explodeSound;

    public int maxHealth;
    public int curHealth;

    public HealthScript healthBar;

    public GameObject TargetTool;

    void Start()
    {
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0 || enemyShip.transform.position.y >= 650)
        {
            FindObjectOfType<AudioManager>().Play(explodeSound);
            GameObject explosion = Instantiate(expEffect, transform.position, transform.rotation);
            Destroy(explosion, 2.0f);
            Destroy(enemyShip);
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
}
