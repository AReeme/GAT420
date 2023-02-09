using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    public DeathState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.animator.SetBool("isDead", true);
        owner.movement.Stop();
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        if (owner.animationDone) 
        {
            GameObject.Destroy(owner.gameObject, 1);
        }
    }
}
