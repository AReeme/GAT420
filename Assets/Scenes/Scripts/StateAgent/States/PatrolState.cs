using UnityEngine;

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
        float timer = Random.Range(0.5f, 1);
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
    }
}
