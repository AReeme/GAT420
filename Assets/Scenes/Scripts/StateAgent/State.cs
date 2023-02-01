using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
	public StateAgent owner { get; private set; }
	public string name { get; private set; }

	public State(StateAgent owner)
	{
		this.owner = owner;
		this.name = this.GetType().Name;
	}

	public abstract void OnEnter(); 
	public abstract void OnExit(); 
	public abstract void OnUpdate(); 
}
