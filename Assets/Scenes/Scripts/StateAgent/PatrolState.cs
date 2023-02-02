using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public PatrolState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.movement.Resume();
        owner.navigation.targetNode = owner.navigation.GetNearestNode();
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        if (owner.perceived.Length > 0)
        {
            owner.stateMachine.StartState(nameof(ChaseState));
        }
    }
}
