using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private bool isHit;
    
    private void OnEnable( )
    {
        isHit = false;
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D( Collider2D col )
    {
        if ( !isHit )
        {
            EnemyController.Singelton.RemoveEnemy();
            isHit = true;
            gameObject.SetActive(false);
        }
    }
}
