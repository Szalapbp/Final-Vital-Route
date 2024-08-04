using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateMachine
{
    public ChaseState(Enemy enemy) : base(enemy) { }
    public override void Enter()
    {
        
    }



    public override void Update()
    {
        if (enemy.player != null)
        {
            enemy.navMeshAgent.SetDestination(enemy.player.position);
        }
    }
    public override void Exit()
    {
     

    }
}
