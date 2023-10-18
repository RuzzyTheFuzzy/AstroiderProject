using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;

    void Start()
    {
        rb.AddForce(Vector2.up * force);
    }

    private void OnTriggerEnter2D( Collider2D col )
    {
        Destroy(gameObject);
    }
}
