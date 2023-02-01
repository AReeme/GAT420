using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Utilities : MonoBehaviour
{
	public static Vector3 Wrap(Vector3 v, Vector3 min, Vector3 max)
	{
		Vector3 result = v;

		if (result.x > max.x) { result.x = min.x; }
		else if (result.x < min.x) { result.x = max.x; }

		if (result.y > max.y) { result.y = min.y; }
		else if (result.y < min.y) { result.y = max.y; }

		if (result.z > max.z) { result.z = min.z; }
		else if (result.z < min.z) { result.z = max.z; }

		return result;
	}

	public static Vector3 ClampMagnitude(Vector3 v, float min, float max)
	{
		return v.normalized * Mathf.Clamp(v.magnitude, min, max);
	}

    public static Vector3[] GetDirectionsInCircle(int num, float angle)
    {
        List<Vector3> result = new List<Vector3>();

        // if odd number, set first direction as forward (0, 0, 1)
        if (num % 2 == 1) result.Add(Vector3.forward);

        // compute the angle between rays
        float angleOffset = (angle * 2) / num;
        // add the +/- directions around the circle
        for (int i = 1; i <= num / 2; i++)
        {
            float modifier = (i == 1 && num % 2 == 0) ? 0.65f : 1;
            result.Add(Quaternion.AngleAxis(+angleOffset * i * modifier, Vector3.up) * Vector3.forward);
            result.Add(Quaternion.AngleAxis(-angleOffset * i * modifier, Vector3.up) * Vector3.forward);
        }

        return result.ToArray();
    }
}
