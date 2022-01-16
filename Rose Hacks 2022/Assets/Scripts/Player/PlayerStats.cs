using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private GameObject pSprite; // For animations
    [SerializeField]
    private SpriteRenderer pSriteRenderer;

    private float spawnX;
    private float spawnY;
    private float spawnRotation;

    public int maxHealth;
    [HideInInspector]
    public int health;


    [SerializeField]
    private float damageInvincibilityLength;  // How long the player is invincible for when hurt in seconds
    private float damageInvincibilityTimer;
    private bool damageInvincible;


    // Color changers
    private Color colorCode;
    private Color flickerCode;
    private float flickerTimer;
    //private Color tintCode;
    //private float tintTimer;



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        spawnX = transform.position.x;
        spawnY = transform.position.y;
        spawnRotation = transform.rotation.eulerAngles.z;

        health = maxHealth;

        damageInvincibilityLength = damageInvincibilityLength / Time.fixedDeltaTime;
        damageInvincible = false;

        colorCode = new Color(1, 1, 1, 1);
        flickerCode = new Color(1, 1, 1, 1);
        //tintCode = new Color(1, 1, 1, 1);
    }



    private void FixedUpdate()
    {
        // Color changers
        FlashUpdate();

        if (flickerTimer > 0)
        {
            FlickerUpdate();
        }

        //else if (tintTimer > 0)
        //{
        //    TintUpdate();
        //}

        pSriteRenderer.color = colorCode;


        if (damageInvincible)
        {
            //pSriteRenderer.color = new Color(1, 1, 1, .5f);  // When invincible after taking damage, make the player 50% opaque/transparent

            // When invincible after taking damage, make the player flicker
            if ((damageInvincibilityTimer % 4) >= 2)
            {
                pSriteRenderer.color = new Color(1, 1, 1, 1);
            }
            else
            {
                pSriteRenderer.color = new Color(1, 1, 1, 0);
            }
        }
        else
        {
            pSriteRenderer.color = new Color(1, 1, 1, 1);
        }

        if (damageInvincibilityTimer <= 0)
        {
            damageInvincible = false;
        }

        damageInvincibilityTimer--;
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        DamageInvincibility();
    }

    void DamageInvincibility()
    {
        damageInvincible = true;
        damageInvincibilityTimer = damageInvincibilityLength;
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (damageInvincible == false)
        {
            // if it touches an enemy's hitbox
            if (obj.gameObject.tag == "Enemy")
            {
                int damage = obj.gameObject.transform.parent.gameObject.GetComponent<Enemy>().damage;
                Debug.Log(damage);
                ApplyDamage(damage);
            }
        }
    }

    // Given a color, makes the enemy that color
    public void Flash(string color)
    {
        if (color == "red")
        {
            colorCode = Color.red;
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
    }

    public void StopFlicker()
    {
        flickerTimer = 0;
    }

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
