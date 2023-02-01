using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private float timer;

    public IdleState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Idle Enter");
        timer = 2;
    }

    public override void OnExit()
    {
        Debug.Log("Idle Exit");
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            owner.stateMachine.StartState(nameof(PatrolState));
        }
    }
}
