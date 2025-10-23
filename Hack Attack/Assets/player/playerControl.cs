using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D r;
    private Vector2 input;
    public event Action OnPlayerDie; //used for player death
    
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() // handles player movement
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }

    private void FixedUpdate()
    {
        r.velocity = input * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) //handles player collision w/ enemy
    {
        chaser enemy = collision.GetComponent<chaser>();
        if (enemy)
        {
            //kill player and run Game Over screen
            OnPlayerDie.Invoke();
        }
    }
}
