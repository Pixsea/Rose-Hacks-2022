using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryTurtle : Enemy
{
    [SerializeField]
    private float walkTime = 5;
    [SerializeField]
    private float telegraphTime = 2;
    [SerializeField]
    private float attackTime = 1;

    [SerializeField]
    private float walkSpeed = 1;
    [SerializeField]
    private float attackSpeed = 5;


    enum Phase { Walking, Telegraphing, Attacking }

    private Phase currPhase = Phase.Walking;


    private void FixedUpdate()
    {
        // Make sure its idle if far away and walking
        if (currPhase == Phase.Walking)
        {
            rb.velocity = Vector2.zero;

        }


        if (Vector3.Distance(transform.position, player.transform.position) < followDistance)
        {
            if (currPhase == Phase.Walking)
            {
                speed = walkSpeed;
                MoveForward();
                TurnTowardsPlayer();
            }
        }

        if (currPhase == Phase.Telegraphing)
        {
            TurnTowardsPlayer();
            rb.velocity = Vector2.zero;
        }
        else if (currPhase == Phase.Attacking)
        {
            speed = attackSpeed;
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
        while (true)
        {
            // Walking
            currPhase = Phase.Walking;
            yield return new WaitForSeconds(walkTime);

            if (Vector3.Distance(transform.position, player.transform.position) < followDistance)
            {
                //Telegraph
                currPhase = Phase.Telegraphing;
                yield return new WaitForSeconds(telegraphTime);

                currPhase = Phase.Attacking;
                yield return new WaitForSeconds(attackTime);
            }
        }
        yield return null;
    }
}
