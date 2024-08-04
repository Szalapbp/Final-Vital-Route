using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerWave = 25;
    public float timeBetweenWaves = 5f;

    private Transform player;
    private int waveNum = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if(player == null)
        {
            Debug.LogError("Player Not Found");
        }
        StartCoroutine(SpawnWaves());


       
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            waveNum++;

            for(int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemies();
                yield return new WaitForSeconds(.5f);
            }

            yield return new WaitForSeconds(timeBetweenWaves);

        }
    }

    void SpawnEnemies()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null )
        {
            enemyScript.player = player;
        }
    }
}
