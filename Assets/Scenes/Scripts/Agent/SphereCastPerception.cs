using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCastPerception : Perception
{
	public Transform raycastTransform;
	[Range(2, 50)] public int numRaycast = 2;
    [Range(0.1f, 10)] public float radius = 1;

    public override GameObject[] GetGameObjects()
    {
        List<GameObject> result = new List<GameObject>();

        Vector3[] directions = Utilities.GetDirectionsInCircle(numRaycast, maxAngle);
        foreach (var direction in directions)
        {
            // cast ray from transform position towards direction 
            Ray ray = new Ray(raycastTransform.position, raycastTransform.rotation * direction);

            if (Physics.SphereCast(ray, radius, out RaycastHit raycastHit, distance))
            {
                // don't perceive self 
                if (raycastHit.collider.gameObject == gameObject) continue;
                // check for tag match 
                if (tagName == "" || raycastHit.collider.CompareTag(tagName))
                {
                    Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);
                    // add game object if ray hit and tag matches 
                    result.Add(raycastHit.collider.gameObject);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.green);
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * distance);
            }

        }

        // sort results by distance 
        result.Sort(CompareDistance);

        return result.ToArray();
    }
}
