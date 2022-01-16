using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Enemy
{
    private void FixedUpdate()
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
}
