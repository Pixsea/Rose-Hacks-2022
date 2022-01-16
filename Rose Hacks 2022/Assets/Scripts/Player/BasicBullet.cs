using System.Collections;
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

    
    private AudioSource audio;
    [SerializeField]
    private AudioClip shootSound;
    [SerializeField]
    private AudioClip impactSound;



    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        audio.PlayOneShot(shootSound, .1f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = gameObject.transform.up * speed;
        rb.velocity = velocity;
    }


    void Dead()
    {
        DestroyObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audio.PlayOneShot(impactSound, .1f);
            collision.gameObject.GetComponent<Enemy>().Damage(power);
            Dead();
        }

        if (collision.gameObject.tag == "Wall")
        {
            Dead();
        }
    }
}
