using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    private Vector2 velocity;  //Vector controlling movement


    private Rigidbody2D rb;

    // Movement keys
    [SerializeField]
    private string Upkey;
    [SerializeField]
    private string Leftkey;
    [SerializeField]
    private string Downkey;
    [SerializeField]
    private string Rightkey;

    // Return true when pushed down
    private bool Uppress;
    private bool Leftpress;
    private bool Downpress;
    private bool Rightpress;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Uppress = Input.GetKey(Upkey);
        Leftpress = Input.GetKey(Leftkey);
        Downpress = Input.GetKey(Downkey);
        Rightpress = Input.GetKey(Rightkey);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        velocity = new Vector2(0.0f, 0.0f);

        if (Uppress)
        {
            velocity.y += speed;
        }
        if (Downpress)
        {
            velocity.y -= speed;
        }
        if (Rightpress)
        {
            velocity.x += speed;
        }
        if (Leftpress)
        {
            velocity.x -= speed;
        }

        rb.velocity = velocity;
    }
}
