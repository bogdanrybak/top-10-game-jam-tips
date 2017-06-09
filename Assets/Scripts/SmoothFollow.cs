using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
	public Transform Target;
	public float SmoothDamp = 0.7f;
	public float MaxSpeed = 100f;
	
	private Vector3 _velocity;

	private void Update()
	{
		if (Target != null) {
			transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _velocity, SmoothDamp, MaxSpeed);
		}
	}
}
