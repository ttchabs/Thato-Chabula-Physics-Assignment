using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AiGoal"))
        {
            Debug.Log("Puck collided with AI GOal");
        }
        else if (gameObject.CompareTag("PlayerGoal"))
        {
            Debug.Log("Puck collided with Player Goal");
        }
    }
}

