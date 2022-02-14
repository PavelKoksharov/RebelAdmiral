using System.Collections;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{
    private Transform target;
    public GameObject targetTool;
    RaycastHit raycastHit;
    private Camera cam;

    private float fireRate;
    public float baseFireRate;

    public GameObject projectilePrefab;
    public GameObject rocketPrefab;
    public GameObject ultimate;
 

    public float baseThirdDuration;
    public float thirdDuration;

    public float[] cooldowns;
    public float[] baseCooldowns;

    public void OnPointerDown()
    {
        if (targetTool != null)
        {
            targetTool.SetActive(false);
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit);
        target = raycastHit.transform;
        var trgt = target.gameObject;
        if (raycastHit.transform != null)
        {
            if (raycastHit.transform.gameObject.tag == "Enemy")
            {
                target = raycastHit.transform;
                EnemyShip script = trgt.GetComponent<EnemyShip>();
                script.TargetTool.SetActive(true);
                targetTool = script.TargetTool;
            }
        }
    }


    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnPointerDown();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1) && cooldowns[0] <= 0)
        {
            RocketBarrage();
            FindObjectOfType<AbilityCD>().SetCD(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && cooldowns[1] <= 0)
        {
            Healing();
            FindObjectOfType<AbilityCD>().SetCD(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && cooldowns[2] <= 0)
        {
            ExtraCharge();
            FindObjectOfType<AbilityCD>().SetCD(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(ultimate);
        }

        RocketFire();

        for (int i = cooldowns.Length-1; i >= 0; i -= 1)
            cooldowns[i] -= Time.deltaTime;

        ExtraChargeOff();
        FindObjectOfType<AbilityCD>().RadialCD(cooldowns);
    }

    void RocketFire()
    {
        if (GameObject.FindGameObjectWithTag("Target") != null)
        {
            if (fireRate <= 0 && targetTool.activeSelf == true)
            {
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 100, transform.position.y - 25, transform.position.z), Quaternion.identity);
                //FindObjectOfType<AudioManager>().Play(shootSound);
                fireRate = baseFireRate;
            }
            else
            {
                fireRate -= Time.deltaTime;
            }
        }
    }

    public void RocketBarrage()
    {
        if (targetTool != null)
        {
            cooldowns[0] = baseCooldowns[0];
            if (targetTool.activeSelf == true)
            {
                for (int i = 0; i < 10; i++)
                    Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    public void Healing()
    {
        cooldowns[1] = baseCooldowns[1];
        FindObjectOfType<PlayerScript>().PlayerHeal(40);
    }

    public void ExtraCharge()
    {
        cooldowns[2] = baseCooldowns[2];
        thirdDuration = baseThirdDuration;
        baseFireRate /= 8;
        //StartCoroutine(ExtraChargeOff());
        //baseFireRate *= 8;
    }

    IEnumerator ExtraChargeOff()
    {
        if (true)
        {
            yield return new WaitForSeconds(baseThirdDuration);
        }
    }
}
