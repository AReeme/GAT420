using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Transition
{
	List<Condition> conditions = new List<Condition>();

	public Transition(Condition[] conditions)
	{
		this.conditions = conditions.ToList();
	}

	public void AddCondition(Condition condition)
	{
		conditions.Add(condition);
	}

	public bool ToTransition()
	{
		// check all conditions, if any false return false else return true
		foreach (var condition in conditions)
		{
			if (!condition.IsTrue()) return false;
		}

		return true;
	}
}
