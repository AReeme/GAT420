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

        var colliders = Physics.OverlapSphere(owner.transform.position, 2);
        foreach(var collider in colliders)
        {
            if (collider.gameObject == owner.gameObject || collider.gameObject.CompareTag(owner.gameObject.tag)) continue;

            if (collider.gameObject.TryGetComponent<StateAgent>(out var component))
            {
                component.health.value -= Random.Range(20, 50);
            }
        }
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
