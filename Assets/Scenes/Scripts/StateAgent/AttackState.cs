using System.Linq;
using UnityEngine;

public class AttackState : State
{
    private float timer;

    public AttackState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Stop();
        owner.animator.SetTrigger("Attack");

        AnimationClip[] clips = owner.animator.runtimeAnimatorController.animationClips;

        AnimationClip clip = clips.FirstOrDefault<AnimationClip>(clip => clip.name == "Punch");
        timer = (clip != null) ? clip.length : 1;
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            owner.stateMachine.StartState(nameof(ChaseState));
        }
    }
}
