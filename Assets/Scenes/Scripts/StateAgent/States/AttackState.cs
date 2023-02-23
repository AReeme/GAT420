using System.Linq;
using UnityEngine;

public class AttackState : State
{
    public AttackState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Stop();

        AnimationClip[] clips = owner.animator.runtimeAnimatorController.animationClips;
        AnimationClip clip = clips.FirstOrDefault<AnimationClip>(clip => clip.name == "Punch");

        var colliders = Physics.OverlapSphere(owner.transform.position, 2);
        foreach(var collider in colliders)
        {
            if (collider.gameObject == owner.gameObject || collider.gameObject.CompareTag(owner.gameObject.tag)) continue;

            if (collider.gameObject.TryGetComponent<StateAgent>(out var component))
            {
                if (component.health.value > 0) 
                {
                    owner.animator.SetTrigger("Attack");
                    component.health.value -= Random.Range(20, 50);
                }
                else
                {
                    owner.stateMachine.StartState(nameof(IdleState));
                }
            }
        }
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
