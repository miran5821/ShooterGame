using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemySpawner;
    public GameObject enemy;

    public GameObject player;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 3f);
    }
    public void SpawnEnemy()
    {
        if (player == null)
            return;
        int index = Random.Range(0, enemySpawner.Length);
        Instantiate(enemy, enemySpawner[index].position, enemySpawner[index].rotation);
    }
}
