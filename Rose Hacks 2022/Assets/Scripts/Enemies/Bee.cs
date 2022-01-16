using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemy
{
    [SerializeField]
    private float attackDelay;

    [SerializeField]
    private GameObject stingerPrefab;

    [SerializeField]
    private float closestDistance = 10f;

    [SerializeField]
    private float slowSpeed = .2f;
    [SerializeField]
    private float regularSpeed = 10;


    private void FixedUpdate()
    {
        if ((Vector3.Distance(transform.position, player.transform.position) < followDistance) && (Vector3.Distance(transform.position, player.transform.position) > closestDistance))
        {
            speed = regularSpeed;
            MoveForward();
            TurnTowardsPlayer();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= closestDistance)
        {
            speed = slowSpeed;
            rb.velocity = Vector2.zero;
            MoveForward();
            TurnTowardsPlayer();
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
            yield return new WaitForSeconds(attackDelay);

            if (Vector3.Distance(transform.position, player.transform.position) < followDistance)
            {
                GameObject stinger = Instantiate(stingerPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;

            }
        }
        yield return null;
    }
}
