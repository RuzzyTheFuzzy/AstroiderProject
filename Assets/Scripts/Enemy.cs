using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public bool IsHit { get; private set; }

    private void OnEnable( )
    {
        IsHit = false;
        rb.velocity = Vector2.down * speed;
    }
    
    public void BulletHit()
    {
        if ( !IsHit )
        {
            EnemyController.Singelton.RemoveEnemy();
            IsHit = true;
            gameObject.SetActive( false );
        }
    }
}