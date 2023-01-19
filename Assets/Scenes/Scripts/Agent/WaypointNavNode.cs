using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WaypointNavNode : NavNode
{
    [SerializeField] private NavNode[] nodes;
    [SerializeField, Range(1, 10)] private float radius = 1;

	private void OnValidate()
	{
		GetComponent<SphereCollider>().radius = radius;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<NavAgent>(out NavAgent navAgent))
		{
			if (navAgent.targetNode == this)
			{
				navAgent.targetNode = nodes[Random.Range(0, nodes.Length)];
			}
		}

	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.TryGetComponent<NavAgent>(out NavAgent navAgent))
		{
			if (navAgent.targetNode == this)
			{
				navAgent.targetNode = nodes[Random.Range(0, nodes.Length)];
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius);

		Gizmos.color = Color.green;
		foreach (NavNode node in nodes)
		{
			Gizmos.DrawLine(transform.position, node.transform.position);
		}
	}
}
