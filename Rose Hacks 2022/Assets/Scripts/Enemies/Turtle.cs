using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Enemy
{
    private bool alive = true;

    private void FixedUpdate()
    {
        if (alive)
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
        StartCoroutine(RunAway());
    }

    IEnumerator RunAway()
    {
        yield return new WaitForSeconds(5);
        DestroyObject(gameObject);
    }
}
