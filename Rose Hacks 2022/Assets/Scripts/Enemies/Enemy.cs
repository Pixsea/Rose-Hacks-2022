using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 50;
    [HideInInspector]
    public int currHealth;

    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public GameObject player;

    public int damage = 10;  // How much damage it does to the player when touched
    public float speed = 10;
    public float rotationSpeed = 10;

    [HideInInspector]
    public bool turning = false; //Used in update loops to control when the enemy should turn to / face the player / moving
    [HideInInspector]
    public bool facingPlayer = false;
    [HideInInspector]
    public bool moving = false;




    // Color changers
    [SerializeField]
    private SpriteRenderer eSriteRenderer;

    [HideInInspector]
    public Color colorCode;
    [HideInInspector]
    public Color flickerCode;
    private float flickerTimer;


    // For animations
    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        currHealth = maxHealth;
        StartCoroutine(ActionLoop());

        colorCode = new Color(1, 1, 1, 1);
        flickerCode = new Color(1, 1, 1, 1);
        //tintCode = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    public virtual void Damage(int damage)
    {
        currHealth -= damage;

        Flash("red");
    }

    public virtual void Dead()
    {
        DestroyObject(gameObject);
    }


    public void MoveForward()
    {
        rb.velocity = transform.up * speed;
    }


    // Turns to player with rotationSpeed
    public void TurnTowardsPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(direction.x, direction.y)) * (180 / Mathf.PI);
        angle = 0 - angle;
        Quaternion angle2 = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, angle2, rotationSpeed);
    }



    // Always faces the player
    public void FacePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(direction.x, direction.y)) * (180 / Mathf.PI);
        angle = 0 - angle;
        Quaternion angle2 = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = angle2;
    }


    public virtual IEnumerator ActionLoop()
    {
        yield return null;
    }






    /// <summary>
    /// Color changing functions
    /// </summary>


    // Call at the end of enemy fixedupdates to modify color
    public virtual void ColorUpdate()
    {
        FlashUpdate();

        if (flickerTimer > 0)
        {
            FlickerUpdate();
        }

        //else if (tintTimer > 0)
        //{
        //    TintUpdate();
        //}

        eSriteRenderer.color = colorCode;
    }



    // Given a color, makes the enemy that color
    public void Flash(string color)
    {
        if (color == "red")
        {
            colorCode = Color.red;
        }

        else if (color == "blue")
        {
            colorCode = Color.blue;
        }
    }

    // Slowly makes the color back to white/basic
    void FlashUpdate()
    {
        if (colorCode.r < 1)
        {
            colorCode.r += .05f;
        }
        if (colorCode.b < 1)
        {
            colorCode.b += .05f;
        }
        if (colorCode.g < 1)
        {
            colorCode.g += .05f;
        }
    }

    // Given a color and a float, causes the enemy to flicker for that amount if time in seconds
    public void Flicker(string color, float time)
    {
        flickerTimer = time / Time.fixedDeltaTime;

        if (color == "red")
        {
            flickerCode = Color.red;
        }

        else if (color == "blue")
        {
            flickerCode = Color.blue;
        }
    }

    public void StopFlicker()
    {
        flickerTimer = 0;
    }

    // Alternate between the enemy being the flickerCode color and regular color
    void FlickerUpdate()
    {
        if ((flickerTimer % 8) >= 4)
        {
            colorCode = flickerCode;
        }
        else
        {
            colorCode = new Color(1, 1, 1, 1);
        }

        flickerTimer--;
    }
}
