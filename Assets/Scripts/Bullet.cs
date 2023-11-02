using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col2D;
    [SerializeField] private float speed;
    [SerializeField] private float hitDistance;

    void Start()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void FixedUpdate( )
    {
        foreach ( var enemy in EnemyController.Singelton.EnemyPool )
        {
            var closestPoint = col2D.ClosestPoint( enemy.transform.position );

            if ( Vector2.Distance( closestPoint, enemy.transform.position ) < hitDistance )
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

    private void OnTriggerEnter2D( Collider2D col )
    {
        Destroy(gameObject);
    }
    
    
    
    
}
