using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPulse : MonoBehaviour
{
    public Transform pulseTransform;
    private float range;
    public float rangeMax = 80f;
    public SphereCollider sphCollider;

    private void Update()
    {
        float rangeSpeed = 10f;
        range += rangeSpeed * Time.deltaTime;
        sphCollider.radius += rangeSpeed * Time.deltaTime;
        if (range >= rangeMax)
        {
            Destroy(gameObject);
        }
        pulseTransform.localScale = new Vector3(range, range);
    }

    private void OnCollisionEnter(Collision enemyCollision)
    {
        if (enemyCollision.gameObject.tag == "Enemy")
        {
            enemyCollision.gameObject.GetComponent<EnemyShip>().EnemyTakeDamage(20);
        }
    }

    private void Start()
    {
        transform.SetParent(Main.canvas, false);
    }
}
