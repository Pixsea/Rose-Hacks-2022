using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private GameObject pSprite; // For animations
    [SerializeField]
    private SpriteRenderer pSriteRenderer;


    private AudioSource audio;
    [SerializeField]
    private AudioClip damageSound;
    [SerializeField]
    private AudioClip collectSound;


    private Vector2 spawnPoint;

    public int maxHealth;
    [HideInInspector]
    public int health;

    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Image happinessMeter;


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

        spawnPoint = gameObject.transform.position;

        health = maxHealth;
        healthText = GameObject.Find("Health Text").GetComponent<Text>();
        happinessMeter = GameObject.Find("Happiness Meter").GetComponent<Image>();
        audio = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        healthText.text = health.ToString();
        happinessMeter.fillAmount = 0;


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


        if (health <= 0)
        {
            Respawn();
            

        }
    }




    public void ApplyDamage(int damage)
    {
        if (damageInvincible)
        {
            return;
        }
        health -= damage;
        healthText.text = health.ToString();
        audio.PlayOneShot(damageSound, .2f);
        DamageInvincibility();
    }

    void DamageInvincibility()
    {
        damageInvincible = true;
        damageInvincibilityTimer = damageInvincibilityLength;
    }

    void Respawn()
    {
        health = maxHealth;
        healthText.text = health.ToString();
        gameObject.transform.position = spawnPoint;
        ChangeHappiness(-.1f);
    }


    public void ChangeHappiness(float changeValue)
    {
        happinessMeter.fillAmount += changeValue;
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

        if (obj.gameObject.tag == "Food")
        {
            Item newItem = obj.gameObject.GetComponent<Item>();
            gameObject.GetComponent<PlayerInventory>().addItem(newItem);
            DestroyObject(obj.gameObject);

            ChangeHappiness(.02f);
            audio.PlayOneShot(collectSound, .2f);
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
