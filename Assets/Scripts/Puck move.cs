using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Puckmove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the object
    }

    void FixedUpdate()
    {
        // Calculate the current velocity magnitude
        float currentSpeed = rb.velocity.magnitude;

        // Check if the current speed exceeds the maximum speed
        if (currentSpeed > speed)
        {
            // Limit the velocity to the maximum speed
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
