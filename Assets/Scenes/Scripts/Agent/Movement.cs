using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[Range(1, 10)] public float maxSpeed = 5;
	[Range(1, 10)] public float minSpeed = 5;
	[Range(1, 100)] public float maxForce = 5;

	public Vector3 velocity { get; set; } = Vector3.zero;
	public Vector3 acceleration { get; set; } = Vector3.zero;
	public Vector3 direction { get { return velocity.normalized; } }

	public void ApplyForce(Vector3 force)
	{
		acceleration += force;
	}

	public void MoveTowards(Vector3 target)
	{
		Vector3 direction = (target - transform.position).normalized;
		ApplyForce(direction * maxForce);
	}

	public void Stop()
	{
		velocity = Vector3.zero;
	}


	void LateUpdate()
	{
		velocity += acceleration * Time.deltaTime;
		velocity = Utilities.ClampMagnitude(velocity, minSpeed, maxSpeed);

		transform.position += velocity * Time.deltaTime;
		if (velocity.sqrMagnitude > 0.1f)
		{
			transform.rotation = Quaternion.LookRotation(velocity);
		}

		acceleration = Vector3.zero;
	}
}
