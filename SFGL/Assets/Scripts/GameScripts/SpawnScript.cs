using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject WingTemplate;
    public GameObject[] stars;
    public GameObject[] obstacles;
    public GameObject[] asteroids;
    public GameObject[] enemies;

    private GameObject enemyPrefab;
    private int enemyCount;
    private int spawnIdx = 0;

    public GameObject playerShip;

    private Vector2 screenBounds;

    public float respawnTime;
    public float respawnObstacleTime;
    public float respawnAsteroidTime;
    public float respawnStarsTime;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        StartCoroutine(EnemyWave());
        StartCoroutine(ObstacleWave());
        StartCoroutine(AsteroidWave());
        StartCoroutine(StarsWave());
    }

    private void Update()
    {
        enemyPrefab = enemies[Random.Range(0, enemies.Length-1)];
    }

    private void SpawnEnemy()
    {
        GameObject striderShip = Instantiate(WingTemplate, new Vector3(Random.Range(1500,500), Random.Range(-500, 500), 0), new Quaternion());
        striderShip.transform.SetParent(Main.canvas, false);
        striderShip.name = @$"wing {spawnIdx}";
        EnemyWing wingScript = striderShip.GetComponent<EnemyWing>();
        wingScript.LaunchWing(enemyPrefab,playerShip);
        spawnIdx++;
    }

    IEnumerator EnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            enemyCount = Random.Range(1, 5);
            while (enemyCount > 0)
            {
                enemyCount--;
                SpawnEnemy();
            }
        }
    }

    IEnumerator ObstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnObstacleTime);
            SpawnObstacle();
        }
    }

    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnAsteroidTime);
            SpawnAsteroid();
        }
    }

    IEnumerator StarsWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnStarsTime);
            SpawnStars();
        }
    }

    private void SpawnAsteroid()
    {
        GameObject ast = Instantiate(asteroids[Random.Range(0, asteroids.Length)]);
        ast.transform.position = new Vector3(screenBounds.x*1.5f, Random.Range(-screenBounds.y, screenBounds.y), 60);
    }

    private void SpawnObstacle()
    {
        GameObject obst = Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
        obst.transform.position = new Vector3(screenBounds.x * 1.5f, Random.Range(-screenBounds.y, screenBounds.y), 60);
    }

    private void SpawnStars()
    {
        GameObject star = Instantiate(stars[Random.Range(0, stars.Length)]);
        star.transform.position = new Vector3(screenBounds.x * 2f, 0, 60);
    }
}

