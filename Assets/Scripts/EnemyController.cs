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

    private int currentEnemyAmount;
    private List<GameObject> enemyPool;

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

        enemyPool = new List<GameObject>();

    }

    void Update( )
    {
        if ( currentEnemyAmount <= 0 )
        {
            maxEnemies++;
            var spawnAmount = maxEnemies - currentEnemyAmount;
            var spawnPos = transform.position;

            for ( int i = 0; i < spawnAmount; i++ )
            {
                var enemyPos = spawnPos;
                enemyPos.x = Random.Range( minSpawnX, maxSpawnX );

                if ( enemyPool.Count > i )
                {
                    var enemy = enemyPool[i];
                    enemy.SetActive( true );
                    enemy.transform.position = enemyPos;
                }
                else
                {
                    enemyPool.Add( Instantiate( enemyPrefab, enemyPos, Quaternion.identity ) );
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