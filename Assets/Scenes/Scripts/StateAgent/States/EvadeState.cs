using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState : State
{
    public EvadeState(StateAgent owner) : base(owner)
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
            Vector3 direction = (owner.transform.position - owner.perceived[0].transform.position).normalized;
            owner.movement.MoveTowards(owner.transform.position + direction * 5);
        }
    }
}
