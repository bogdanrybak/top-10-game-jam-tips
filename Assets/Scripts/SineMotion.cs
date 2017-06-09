using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMotion : MonoBehaviour
{
	public Transform Target;

	public float Duration = 1f;
	public Vector3 From;
	public Vector3 To;
	public Vector3 Offset;

	private Vector3 startingOffset;

	private void Start() {
		if (Target == null) {
			Target = transform;
		}

		startingOffset = Target.localPosition;
	}

	void Update()
	{
		Vector3 pos = Target.localPosition;
		pos.x = Auto.Wave(Duration, From.x, To.x, Offset.x);
		pos.y = Auto.Wave(Duration, From.y, To.y, Offset.y);
		pos.z = Auto.Wave(Duration, From.z, To.z, Offset.z);
		Target.localPosition = startingOffset + pos;
	}
}