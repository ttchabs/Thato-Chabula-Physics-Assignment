 using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AImovement : MonoBehaviour
{
 public float MaxMovementSpeed;
 private Rigidbody2D rb;
 private Vector2 startingposition;

 public Rigidbody2D Puck;

 public Transform PlayerBoundaryHolder;
 private PlayerPaddleMovement.Boundary playerBoundary;

 public Transform PuckBoundaryHolder;
 private PlayerPaddleMovement.Boundary puckBoundary;

 private Vector2 targetPosition;

 private void Start()
 {
  rb = GetComponent<Rigidbody2D>();
  startingposition = rb.position;

  playerBoundary = new PlayerPaddleMovement.Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
   PlayerBoundaryHolder.GetChild(1).position.y, PlayerBoundaryHolder.GetChild(2).position.x,
   PlayerBoundaryHolder.GetChild(3).position.x);

  puckBoundary = new PlayerPaddleMovement.Boundary(PuckBoundaryHolder.GetChild(0).position.y,
   PuckBoundaryHolder.GetChild(1).position.y, PuckBoundaryHolder.GetChild(2).position.x,
   PuckBoundaryHolder.GetChild(3).position.x);
  
 }

 private void FixedUpdate()
 {
  float movementSpeed;

  if (Puck.position.x < puckBoundary.Left)
  {
   movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
   targetPosition = new Vector2(Mathf.Clamp(Puck.position.y, playerBoundary.Down, playerBoundary.Up),
    startingposition.x);


  }
  else
  {
   movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
   targetPosition = new Vector2(Mathf.Clamp(Puck.position.y, playerBoundary.Down, playerBoundary.Up),
    Mathf.Clamp(Puck.position.x, playerBoundary.Right, playerBoundary.Left));
  }

 rb.MovePosition(Vector2.MoveTowards(rb.position,targetPosition,movementSpeed * Time.fixedDeltaTime)); 
 }
}
 


