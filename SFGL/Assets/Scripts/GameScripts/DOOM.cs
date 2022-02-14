using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(Main.canvas, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision enemyCollision)
    {
        if (enemyCollision.gameObject.tag == "Enemy")
        {
            enemyCollision.gameObject.GetComponent<EnemyShip>().EnemyTakeDamage(2000);
        }
        else if (enemyCollision.gameObject.tag == "Player")
        {
            enemyCollision.gameObject.GetComponent<PlayerScript>().PlayerTakeDamage(1000);
        }
    }
}
