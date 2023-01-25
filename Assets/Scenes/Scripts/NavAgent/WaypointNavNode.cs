using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WaypointNavNode : NavNode
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<NavAgent>(out NavAgent navAgent))
		{
			if (navAgent.targetNode == this && neighbors.Count > 0)
			{
				navAgent.targetNode = navAgent.GetNextTarget(navAgent.targetNode);
			}
		}

	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.TryGetComponent<NavAgent>(out NavAgent navAgent))
		{
			if (navAgent.targetNode == this && neighbors.Count > 0)
			{
				navAgent.targetNode = navAgent.GetNextTarget(navAgent.targetNode);
			}
		}
	}
}