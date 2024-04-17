using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AImovement : MonoBehaviour
{
    public float AiMaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D Puck;

    public Transform PlayerBounderHolder;
    private PlayerPaddleMovement.Boundary playerBoundary;

    public Transform PuckBoundaryHolder;
    private PlayerPaddleMovement.Boundary puckBoundary;

    private Vector2 targetPosition;

    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetXFromTarget;

    private float distance;
    private float Direction;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        
        playerBoundary = new PlayerPaddleMovement.Boundary(PlayerBounderHolder.GetChild(0).position.y,
            PlayerBounderHolder.GetChild(1).position.y,
            PlayerBounderHolder.GetChild(2).position.x,
            PlayerBounderHolder.GetChild(3).position.x);
        
        playerBoundary = new PlayerPaddleMovement.Boundary(PuckBoundaryHolder.GetChild(0).position.y,
            PuckBoundaryHolder.GetChild(1).position.y,
            PuckBoundaryHolder.GetChild(2).position.x,
            PuckBoundaryHolder.GetChild(3).position.x);
    }

    private void FixedUpdate()
    {
        float movementSpeed;

        if (Puck.position.x < puckBoundary.Left)
        {
            if (isFirstTimeInOpponentsHalf)
            {
                isFirstTimeInOpponentsHalf = false;
                offsetXFromTarget = Random.Range(-1f, 1f);
            }

            movementSpeed = AiMaxMovementSpeed * Random.Range(0.4f, 0.5f);
            targetPosition = new Vector2(
                Mathf.Clamp(Puck.position.x + offsetXFromTarget, playerBoundary.Left, playerBoundary.Right),
                startingPosition.y);

        }
        else
        {
            isFirstTimeInOpponentsHalf = true;

            movementSpeed = Random.Range(AiMaxMovementSpeed * 0.4f, AiMaxMovementSpeed);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left, playerBoundary.Right),
                Mathf.Clamp(Puck.position.y, playerBoundary.Down, playerBoundary.Up));


        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

        if (Puck.position.x > 0)
        {
            
        }




    }
}

