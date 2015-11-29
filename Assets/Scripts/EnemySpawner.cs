using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    private Resource enemyPool;
    public int enemyLimit;
    public Rigidbody2D enemy;
    private int poolIndex = 0;
    public float spawnTimer;
    private float deltaTime = 0.0F;




    // Use this for initialization
    void Start()
    {
        enemyPool = new Resource(enemy, enemyLimit, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(deltaTime > spawnTimer)
        {
            spawnEnemy();
            deltaTime = 0.0F;
        } else
        {
            deltaTime += Time.deltaTime;
        }
            
            
    }


    void spawnEnemy()
    {
        Rigidbody2D realEnemy = enemyPool.getNext();
        realEnemy.transform.position = transform.position;
        realEnemy.gameObject.SetActive(true);
        realEnemy.GetComponent<Enemy>().ResetHealth();
        

    }
}
