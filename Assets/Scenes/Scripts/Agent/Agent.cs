using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
	public Perception perception;
	public Movement movement;
    [SerializeField] public Animator animator;
	public Navigation navigation;
}
