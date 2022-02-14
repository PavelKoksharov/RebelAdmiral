using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWing : MonoBehaviour
{
    List<GameObject> ships;
    public GameObject shipPrefab;
    private GameObject playerShip;

    public float speed;

    private Vector3 walkPoint;
    bool walkPointSet;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    // Start is called before the first frame update
    private void Awake()
    {
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkPoint, speed * Time.deltaTime);
        }
    }
    private void SearchWalkPoint()
    {
        walkPoint = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), 60.0f);
        walkPointSet = true;
    }


    public void LaunchWing(GameObject shipPrefab, GameObject playerShip)
    {
        this.playerShip = playerShip;
        this.shipPrefab = shipPrefab;
        ships = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            GameObject newShip = Instantiate(shipPrefab, gameObject.transform);
            ships.Add(newShip);
            newShip.transform.localPosition = new Vector3(50*i, 75 * i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }
}
