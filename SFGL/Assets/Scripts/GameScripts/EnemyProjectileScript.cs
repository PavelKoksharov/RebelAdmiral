using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyProjectileScript : MonoBehaviour
{
    public string typeOfAmmo;
    public float speed;

    public string explodeSound;
    public GameObject hitEffect;

    private Transform player;
    private Vector3 target;

    public Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            rb = GetComponent<Rigidbody>();
            rb.angularVelocity = new Vector3(0,0,0);
            FindObjectOfType<AudioManager>().Play(explodeSound);
            GameObject empExp = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(empExp, 2.0f);
            Destroy(gameObject);
            FindObjectOfType<PlayerScript>().PlayerTakeDamage(20);
        }
    }
}