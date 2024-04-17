using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public Scores ScoreScriptInstance;
    public static bool wasGoal { get; private set; }
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!wasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(Scores.Score.PlayerScore);
                wasGoal = true;
                StartCoroutine(ResetPuck());
            }
            else if (other.tag == "PlayerScore")
            {
                ScoreScriptInstance.Increment(Scores.Score.PlayerScore);
                wasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
    
    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(0);
        wasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
    }
}
    
