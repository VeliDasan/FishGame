using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 2f;
    public int maxEnemies = 4;

    private int currentEnemies = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            currentEnemies++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemies>();
        newEnemy.transform.parent = transform; // Düþmaný "EnemySpawner"ýn alt nesnesi yap
    }

    public void DecreaseEnemyCount()
    {
        currentEnemies--;
        StartCoroutine(RespawnEnemy());
    }

    IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy();
    }
}
