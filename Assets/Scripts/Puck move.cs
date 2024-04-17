using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Puckmove : MonoBehaviour
{
    public float speed = 5f;
    private void Update()
    
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AndStart();
        }
    }

    void AndStart()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector3.right * speed;
        }
    }
}
