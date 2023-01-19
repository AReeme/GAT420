using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavNode : MonoBehaviour
{
	public static NavNode[] GetNodes()
	{
		return FindObjectsOfType<NavNode>();
	}

	public static NavNode GetRandomNode()
	{
		var nodes = GetNodes();
		return (nodes == null) ? null : nodes[Random.Range(0, nodes.Length)];
	}
}
