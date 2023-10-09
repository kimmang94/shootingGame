using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime = 0f;
    private float createTime = 3f;
    [SerializeField] private GameObject enemyFactory;
    private float minTime = 0.5f;
    private float maxTime = 1.5f;

    private int poolSize = 10;
    public List<GameObject> enemyObjectPool;
    [SerializeField] private Transform[] spawnPoints;
    
    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemyObjectPool.Remove(enemy);
                
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                enemy.SetActive(true);
            }


            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;

        }
    }
}
