using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Singelton;

    [SerializeField] private int maxEnemies;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnX;
    [SerializeField] private float maxSpawnX;
    [SerializeField] private float timeUntillRespawn; // Using timer as distance checking is slow

    private float respawnTimer;

    private int currentEnemyAmount;
    public List<GameObject> EnemyPool { get; private set; }

    private void Start( )
    {
        if ( Singelton )
        {
            Destroy( gameObject );
        }
        else
        {
            Singelton = this;
        }

        EnemyPool = new List<GameObject>();

    }

    void Update( )
    {
        respawnTimer += Time.deltaTime;

        if ( respawnTimer >= timeUntillRespawn )
        {
            currentEnemyAmount = 0;
            respawnTimer = 0;
        }
        
        if ( currentEnemyAmount <= 0 )
        {
            maxEnemies++;
            var spawnAmount = maxEnemies - currentEnemyAmount;
            var spawnPos = transform.position;

            for ( int i = 0; i < spawnAmount; i++ )
            {
                var enemyPos = spawnPos;
                enemyPos.x = Random.Range( minSpawnX, maxSpawnX );

                if ( EnemyPool.Count > i )
                {
                    var enemy = EnemyPool[i];
                    enemy.SetActive( true );
                    enemy.transform.position = enemyPos;
                }
                else
                {
                    EnemyPool.Add( Instantiate( enemyPrefab, enemyPos, Quaternion.identity ) );
                }

                currentEnemyAmount++;
            }
        }
    }

    public void RemoveEnemy( )
    {
        currentEnemyAmount--;
    }
}