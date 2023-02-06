using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class PatrolState : State
{
    private float timer;

    public PatrolState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.movement.Resume();
        owner.navigation.targetNode = owner.navigation.GetNearestNode();
        float timer = Random.Range(5, 10);
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            owner.stateMachine.StartState(nameof(WanderState));
        }

        if (owner.perceived.Length > 0)
        {
            owner.stateMachine.StartState(nameof(ChaseState));
        }

        if (owner.perceived.Length == 0)
        {
            owner.stateMachine.StartState(nameof(IdleState));
        }
        else
        {
            // move towards the perceived object position 
            owner.movement.MoveTowards(owner.perceived[0].transform.position);

            // create a direction vector toward the perceieved object from the owner
            Vector3 direction = owner.perceived[0].transform.position - owner.transform.position;
            // get the distance to the perceived object 
            float distance = direction.magnitude;
            // get the angle between the owner forward vector and the direction vector 
            float angle = Vector3.Angle(owner.transform.forward, direction);
            // if within range and angle, attack 
            if (distance < 2.5 && angle < 20)
            {
                owner.stateMachine.StartState(nameof(AttackState));
            }
        }
    }
}
