using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour
{
    public string typeOfAmmo;
    public float speed;
    public Transform target;
    public GameObject targetObj;

    private Camera mainCamera;
    private GameObject player;

    private LineRenderer mLineRenderer;

    //public string explodeSound;
    public GameObject hitEffect;
    private Vector3 targetPos;

    void Start()
    {
        mainCamera = Camera.main;
        mLineRenderer = GetComponent<LineRenderer>();
        player = Main.player;
        if (GameObject.FindGameObjectWithTag("Target") != null)
        {
            targetObj = GameObject.FindGameObjectWithTag("Target");
            target = targetObj.transform;

            Vector3 targetPos = new Vector3(target.transform.position.x + 50.0f,
                                            target.position.y + 20 - Random.Range(0, 50),
                                            target.position.z);

            if (typeOfAmmo == "Laser")
            {
                DrawRay(targetPos, player.transform.position);
                target.transform.parent.GetComponent<EnemyShip>().EnemyTakeDamage(100);
                Destroy(gameObject, 0.3f);
            }

            if (typeOfAmmo == "Ray")
            {
                DrawRay(new Vector3(target.position.x+ 40, target.position.y-10,target.position.z-10),                    
                    player.transform.position);
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                gameObject.transform.LookAt(targetPos);
            }
        }
    }

    void FixedUpdate()
    {
        if (typeOfAmmo == "Rocket")
            this.speed += 500 * Time.deltaTime;
        if (typeOfAmmo == "Ray")
        {
            if (GameObject.FindGameObjectWithTag("Target") == null)
                Destroy(gameObject);
            else
                target.transform.parent.GetComponent<EnemyShip>().EnemyTakeDamage(1);
        }
    }

    private void OnCollisionEnter(Collision enemyCollision)
    {
        if (enemyCollision.gameObject.tag == "Enemy")
        {
            //FindObjectOfType<AudioManager>().Play(explodeSound);
            GameObject empExp = Instantiate(hitEffect, new Vector3(transform.position.x, transform.position.y + 30, transform.position.z), transform.rotation);
            Destroy(empExp, 2.0f);
            Destroy(gameObject);
            enemyCollision.gameObject.GetComponent<EnemyShip>().EnemyTakeDamage(20);
        }
    }

    void DrawRay(Vector3 startPos, Vector3 endPos)
    {
        mLineRenderer.SetPosition(0, startPos);
        mLineRenderer.SetPosition(1, endPos);
    }
}
