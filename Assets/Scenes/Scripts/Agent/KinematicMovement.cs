using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicMovement : Movement
{
	public override void ApplyForce(Vector3 force)
	{
		acceleration += force;
	}

	public override void MoveTowards(Vector3 target)
	{
		Vector3 direction = (target - transform.position).normalized;
		ApplyForce(direction * maxForce);
	}

    public override void Stop()
	{
		velocity = Vector3.zero;
	}

    public override void Resume()
    {
        //
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
