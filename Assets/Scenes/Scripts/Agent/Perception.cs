using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
	[Range(1,40)] public float distance = 1.0f;
	[Range(0, 180)] public float angle = 45.0f;

	public GameObject[] GetGameObjects()
	{
		List<GameObject> result = new List<GameObject>();

		Collider[] colliders = Physics.OverlapSphere(transform.position, distance);
		foreach (Collider collider in colliders)
		{
			if (collider.gameObject == gameObject) continue;

			result.Add(collider.gameObject);
		}
		return result.ToArray();
	}
}
