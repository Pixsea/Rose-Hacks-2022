using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{
    [SerializeField]
    private float walkTime = 5;
    [SerializeField]
    private float telegraphTime = 2;
    [SerializeField]
    private float attackTime = 1;

    [SerializeField]
    private GameObject venom;
    [SerializeField]
    private int sprayAmount = 50;
    [SerializeField]
    private float sprayDelay = .1f;


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
                MoveForward();
                TurnTowardsPlayer();
            }
        }

        if (currPhase == Phase.Telegraphing)
        {
            rb.velocity = Vector2.zero;
        }
        else if (currPhase == Phase.Attacking)
        {
            rb.velocity = Vector2.zero;

        }

        if (currHealth <= 0)
        {
            Dead();
        }

        ColorUpdate();
    }


    IEnumerator SprayAttack()
    {
        int amount = sprayAmount;
        while (amount > 0)
        {
            amount--;
            Quaternion newDirection = gameObject.transform.rotation * Quaternion.Euler(0, 0, Random.Range(-15f, 15f));
            GameObject newVenom = Instantiate(venom, gameObject.transform.position, newDirection) as GameObject;

            yield return new WaitForSeconds(sprayDelay);
        }
        yield return null;
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
                animator.SetTrigger("Charge");
                yield return new WaitForSeconds(telegraphTime);

                currPhase = Phase.Attacking;
                animator.SetTrigger("Attack");
                StartCoroutine(SprayAttack());
                yield return new WaitForSeconds(attackTime);
                animator.SetTrigger("Slither");
            }
        }
        yield return null;
    }
}
