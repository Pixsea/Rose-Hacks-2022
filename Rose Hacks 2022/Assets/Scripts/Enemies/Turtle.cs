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

            if (currHealth <= 0)
            {
                Dead();
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
        GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity) as GameObject;
        StartCoroutine(RunAway());
    }

    IEnumerator RunAway()
    {
        yield return new WaitForSeconds(5);
        DestroyObject(gameObject);
    }
}
