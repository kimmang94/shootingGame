using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float _speed = 5f;
    private int minValue = 0;
    private int maxValue = 10;
    private Vector3 dir;
    [SerializeField] private GameObject explosionFactory;
    private void Start()
    {
        int randValue = Random.Range(minValue, maxValue);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += dir * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++;
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }

        gameObject.SetActive(false);
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        manager.enemyObjectPool.Add(gameObject);
    }
}
