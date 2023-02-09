using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	public State currentState { get; set; }

    private Dictionary<State, List<KeyValuePair<Transition, State>>> stateTransitions = new Dictionary<State, List<KeyValuePair<Transition, State>>>();
    private Dictionary<string, State> states = new Dictionary<string, State>();

    private List<KeyValuePair<Transition, State>> anyTransitions = new List<KeyValuePair<Transition, State>>();

    public void Update()
	{
        // check state transitions
        // get transitions for current state
        if (stateTransitions.TryGetValue(currentState, out var transitions))
        {
            // check all transtions
            foreach (var transition in transitions)
            {
                // check for transition to new state
                if (transition.Key.ToTransition())
                {
                    StartState(transition.Value.name);
                    break;
                }
            }
        }

        // check for any transition
        foreach (var transition in anyTransitions)
        {
            // check for transition
            if (transition.Key.ToTransition())
            {
                StartState(transition.Value.name);
                break;
            }
        }

        currentState?.OnUpdate();
	}

	public void StartState(string name)
	{
		State newState = states[name];
		if (newState == null || newState == currentState) return;

		currentState?.OnExit();
		currentState = newState;
		currentState?.OnEnter();
	}

	public void AddState(State state)
	{
		if (states.ContainsKey(state.name)) return;
		states[state.name] = state;
	}

    public void AddTransition(string stateFrom, Transition transition, string stateTo)
    {
        if (!stateTransitions.ContainsKey(GetStateFromName(stateFrom)))
        {
            stateTransitions[GetStateFromName(stateFrom)] = new List<KeyValuePair<Transition, State>>();
        }
        stateTransitions[GetStateFromName(stateFrom)].Add(new KeyValuePair<Transition, State>(transition, GetStateFromName(stateTo)));
    }

    public void AddAnyTransition(Transition transition, string stateTo)
    {
        anyTransitions.Add(new KeyValuePair<Transition, State>(transition, GetStateFromName(stateTo)));
    }

    public State GetStateFromName(string name)
    {
        foreach (var state in states)
        {
            if (string.Equals(state.Key, name, System.StringComparison.OrdinalIgnoreCase))
            {
                return state.Value;
            }
        }

        return null;
    }
}
