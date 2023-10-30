using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private bool isHit;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnDestroy( )
    {
        if ( !isHit )
        {
            EnemyController.Singelton.RemoveEnemy();
            isHit = true;
        }
    }
}
