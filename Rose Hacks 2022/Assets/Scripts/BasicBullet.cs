﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    [SerializeField]
    private int power = 10;
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float timer = 5.0f;

    private Vector2 velocity;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = gameObject.transform.up * speed;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == )
    }
}
