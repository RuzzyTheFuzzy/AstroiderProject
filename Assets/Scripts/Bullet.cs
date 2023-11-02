using System;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float hitDistance; // Half radius of bullet and enemy combined

    void Start()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void Update( )
    {
        if ( transform.position.y > 10 )
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate( )
    {
        foreach ( var enemy in EnemyController.Singelton.EnemyPool )
        {
            var enemyPos = enemy.transform.position;
            var bulletPos = transform.position;
            
            // Ignore the enemies if the wave cant be within range of the bullets
            if ( math.abs( enemyPos.y - bulletPos.y ) > hitDistance ) 
            {
                var enemyComp = enemy.GetComponent<Enemy>();
                
                if ( enemyComp )
                {
                    if ( !enemyComp.IsHit )
                    {
                        break;
                    }
                }
            }
            
            if ( Vector2.Distance( bulletPos, enemyPos ) < hitDistance )
            {
                var enemyComp = enemy.GetComponent<Enemy>();

                if ( enemyComp )
                {
                    if ( !enemyComp.IsHit )
                    {
                        enemyComp.BulletHit();
                    }
                }
            }
        }
    }
}
