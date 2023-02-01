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
        Debug.Log("Chase Enter");
    }

    public override void OnExit()
    {
        Debug.Log("Chase Exit");
    }

    public override void OnUpdate()
    {
        if (owner.perceived.Length == 0)
        {
            owner.stateMachine.StartState(nameof(IdleState));
        }
    }
}
