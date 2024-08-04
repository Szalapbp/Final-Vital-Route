using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachine
{
    public IdleState(Enemy enemy) : base(enemy)
    {

    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.position);

        if (distanceToPlayer < enemy.chaseDistance)
        {
            enemy.ChangeState(new ChaseState(enemy));
        }
    }
}
