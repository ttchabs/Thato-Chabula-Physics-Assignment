using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class puck : MonoBehaviour
{
    public Scores ScoreScriptInstance;
    public Transform portal1;
    public Transform portal2;
    private bool canTeleport = true;
    public float teleportCooldown = 0.3f;

    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(Scores.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
            else if (other.tag == "PlayerGoal")
            {
               ScoreScriptInstance.Increment(Scores.Score.AiScore);
               WasGoal = true;
               StartCoroutine(ResetPuck());
            }
        }
        
        if (canTeleport && (other.transform == portal1 || other.transform == portal2))
        {
            // Teleport the puck to the opposite portal
            Transform targetPortal = other.transform == portal1 ? portal2 : portal1;
            transform.position = targetPortal.position;

            // Invert the y velocity
            //rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);

            // Start cooldown timer
            canTeleport = false;
            Invoke("ResetTeleportCooldown", teleportCooldown);
        }

    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(0);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
    }

    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }
    
    private void ResetTeleportCooldown()
    {
        canTeleport = true;
    }
    
}
    
