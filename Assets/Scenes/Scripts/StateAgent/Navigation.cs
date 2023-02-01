using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Navigation : MonoBehaviour
{
	public NavNode targetNode { get; set; } = null;


	public NavNode GetNextNavTarget(NavNode node)
	{
		return node.neighbors[Random.Range(0, node.neighbors.Count)];
	}

	public NavNode GetNearestNode()
	{
		var nodes = NavNode.GetNodes().ToList();
		SortByDistance(nodes);

		return (nodes.Count == 0) ? null : nodes[0];
	}


	public void SortByDistance(List<NavNode> nodes)
	{
		nodes.Sort(CompareDistance);
	}

	public int CompareDistance(NavNode a, NavNode b)
	{
		float squaredRangeA = (a.transform.position - transform.position).sqrMagnitude;
		float squaredRangeB = (b.transform.position - transform.position).sqrMagnitude;
		return squaredRangeA.CompareTo(squaredRangeB);
	}


}
