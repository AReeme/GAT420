using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    private Vector3 target;
    private float reachThreshold = 0.1f;

    public WanderState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Resume();

        // create random target position around owner
        target = GetRandomTargetPosition(owner.transform.position, 5.0f, 360.0f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        // draw debug line from current position to target position 
        Debug.DrawLine(owner.transform.position, target);
        owner.movement.MoveTowards(target);

        // Check if the agent has reached the target position
        if (Vector3.Distance(owner.transform.position, target) < reachThreshold)
        {
            owner.stateMachine.StartState(nameof(AttackState));
        }
    }

    private Vector3 GetRandomTargetPosition(Vector3 ownerPosition, float distance, float angle)
    {
        return ownerPosition + Quaternion.AngleAxis(Random.Range(0, angle), Vector3.up) * Vector3.forward * distance;
    }
}

