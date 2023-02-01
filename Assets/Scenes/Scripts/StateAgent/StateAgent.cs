using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAgent : Agent
{
    public StateMachine stateMachine = new StateMachine();
    public GameObject[] perceived;

    void Start()
    {
        stateMachine.AddState(new IdleState(this));
        stateMachine.AddState(new PatrolState(this));
        stateMachine.AddState(new ChaseState(this));
        stateMachine.StartState(nameof(IdleState));
    }

    void Update()
    {
        perceived= perception.GetGameObjects();

        stateMachine.Update();

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetFloat("Speed", 0.5f);
        } else {
            animator.SetFloat("Speed", 0);
        }
    }
}
