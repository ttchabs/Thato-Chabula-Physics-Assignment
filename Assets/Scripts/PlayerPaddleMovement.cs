using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleMovement : MonoBehaviour
{
    private bool wasJustClicked = true;
    private bool canMove;
    private Vector2 playerSize;
    private Vector2 startingPosition;

    private Rigidbody2D rb;

    public Transform BorderBoundaries;
    Boundary playerBoundary;


   public struct Boundary
    {
        public float Up, Down, Left, Right;

        public Boundary(float up, float down, float left, float right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }
    }

    private void Start()
    {
       
        playerSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position; 

        playerBoundary = new Boundary(BorderBoundaries.GetChild(0).position.y,
            BorderBoundaries.GetChild(1).position.y,
            BorderBoundaries.GetChild(2).position.x,
            BorderBoundaries.GetChild(3).position.x);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if ((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + playerSize.x ||
                     mousePos.x <= transform.position.x && mousePos.x > transform.position.x - playerSize.x) &&
                    (mousePos.y >= transform.position.y && mousePos.y < transform.position.y + playerSize.y ||
                     mousePos.y <= transform.position.y && mousePos.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left,
                        playerBoundary.Right), 
                    Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up));
                
               rb.MovePosition(clampedMousePos);
            }
        }
        else
        {
            wasJustClicked = true;
        }

}

    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
}
   
