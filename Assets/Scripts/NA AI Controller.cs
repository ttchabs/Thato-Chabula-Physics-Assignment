using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
   public Rigidbody2D puck;
   public float speed;
   public Transform PlayerBounderyHolder;
   


   private float distance;


   private void Update()
   {
       distance = Vector2.Distance(transform.position, puck.transform.position);
       Vector2 direction = puck.transform.position - transform.position;

       transform.position = Vector2.MoveTowards(this.transform.position, puck.transform.position, speed * Time.deltaTime);
       
   
   }
   
   
}

