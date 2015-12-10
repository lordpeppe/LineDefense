using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    private Resource enemyPool;
    public int enemyLimit;
    public Rigidbody2D enemy;

    public float spawnTimer;
    private float deltaTime = 0.0F;

    void Start()
    {
        enemyPool = new Resource(enemy, enemyLimit, transform.position);
    }

    void Update()
    {
        if (deltaTime > spawnTimer)
        {
            SpawnEnemy();
            deltaTime = 0.0F;
        }
        else
        {
            deltaTime += Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        Rigidbody2D realEnemy = enemyPool.GetNext();
        realEnemy.transform.position = transform.position;
        realEnemy.gameObject.SetActive(true);
        realEnemy.GetComponent<Enemy>().ResetHealth();

    }
}