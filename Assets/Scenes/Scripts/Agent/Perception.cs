using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perception : MonoBehaviour
{
	public string tagName = "";
	[Range(1,40)] public float distance = 1.0f;
	[Range(0, 180)] public float maxAngle = 45.0f;

	public abstract GameObject[] GetGameObjects();

	public void SortByDistance(List<GameObject> gameObjects)
	{
		gameObjects.Sort(CompareDistance);
	}

	public int CompareDistance(GameObject a, GameObject b)
    {
        float squaredRangeA = (a.transform.position - transform.position).sqrMagnitude;
        float squaredRangeB = (b.transform.position - transform.position).sqrMagnitude;
        return squaredRangeA.CompareTo(squaredRangeB);
    }
}
