using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _cashedMovement;

    // Update is called once per frame
    void Update()
    {
        var mod = Time.deltaTime;
        if ( Input.GetKey( "w") )
        {
            _cashedMovement.y += mod * speed;
        }
        if ( Input.GetKey( "s" ) )
        {
            _cashedMovement.y += -mod * speed;
        }
        if ( Input.GetKey( "a" ) )
        {
            _cashedMovement.x += -mod * speed;
        }
        if ( Input.GetKey( "d" ) )
        {
            _cashedMovement.x += mod * speed;
        }
    }

    private void FixedUpdate( )
    {
        rb.AddForce(_cashedMovement);
        _cashedMovement = Vector2.zero;
    }
}
