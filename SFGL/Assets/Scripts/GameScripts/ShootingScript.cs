using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectile;

    public string shootSound;
    public float reloadTime;
    public float baseReloadTime;

    void Update()
    {
            if (reloadTime <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play(shootSound);
                reloadTime = baseReloadTime;
            }
            else
            {
                reloadTime -= Time.deltaTime;
            }
    }
}
