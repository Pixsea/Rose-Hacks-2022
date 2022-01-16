using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Enemy
{

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < followDistance)
        {
            MoveForward();
            TurnTowardsPlayer();
        }

        ColorUpdate();
        if (currHealth <= 0)
        {
            Dead();
        }
    }
}
