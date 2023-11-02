using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float shootDelay;
    [SerializeField] private GameObject bulletPrefab;
    
    private Vector2 cashedMovement;
    private float timer;
    private bool shooting;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey( "a" ) )
        {
            cashedMovement.x = -speed;
        }
        if ( Input.GetKey( "d" ) )
        {
            cashedMovement.x = speed;
        }

        if (!shooting) // else we need to press it exactly before fixed update
            shooting = Input.GetKeyDown( "space" );
    }

    private void FixedUpdate( )
    {
        rb.velocity = cashedMovement;
        cashedMovement = Vector2.zero;

        if ( shooting )
        {

            Instantiate( bulletPrefab, transform.position, Quaternion.identity );
            
            shooting = false;
        }
    }
}
