using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Resume();
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        if (owner.enemySeen)
        {
            // reset timer
            owner.timer.value = 2;
            // move towards the perceived object position
            owner.movement.MoveTowards(owner.perceived[0].transform.position);
        }
    }
}
