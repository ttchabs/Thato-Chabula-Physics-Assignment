using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondndAiMovement : MonoBehaviour
{
    public Transform Puck;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    private Vector2 startingPosition;
    

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
    }

    private void Update()
    {
        Vector3 direction = Puck.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
        if (Puck.position.x > 0f)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, startingPosition, moveSpeed* Time.fixedDeltaTime));
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + ( direction * moveSpeed * Time.deltaTime));

       
    }

    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
}


    
    
