using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Enemy
{
    private bool alive = true;
    [SerializeField]
    private GameObject shellPrefab;  //  Shell item to drop

    private void FixedUpdate()
    {
        if (alive && (Vector3.Distance(transform.position, player.transform.position) < followDistance))
        {
            if (moving)
            {
                MoveForward();
                TurnTowardsPlayer();
            }
        }
        else if (alive)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            MoveForward();
        }

        ColorUpdate();
        if (currHealth <= 0)
        {
            Dead();
        }
    }

    public override IEnumerator ActionLoop()
    {
        if (true)
        {
            moving = true;
        }
        yield return null;
    }

    public override void Dead()
    {
        speed *= -10;
        alive = false;
        animator.SetTrigger("Dead");
        currHealth = 1000;
        GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity) as GameObject;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(RunAway());
    }

    IEnumerator RunAway()
    {
        yield return new WaitForSeconds(5);
        DestroyObject(gameObject);
    }
}
