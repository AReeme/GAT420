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
        Debug.Log("Patrol Enter");
    }

    public override void OnExit()
    {
        Debug.Log("Patrol Exit");
    }

    public override void OnUpdate()
    {
        if (owner.perceived.Length > 0)
        {
            owner.stateMachine.StartState(nameof(ChaseState));
        }
    }
}
