using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderState : State
{
    private Vector3 target;

    public WanderState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Resume();
        // create random target position around owner 
        target = owner.transform.position + Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.forward * 5;
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        // draw debug line from current position to target position 
        Debug.DrawLine(owner.transform.position, target);
        owner.movement.MoveTowards(target);
        if (owner.movement.velocity.magnitude == 0) 
        {
            owner.stateMachine.StartState(nameof(IdleState));
        }
    }
}

