using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public Vector3 RotationVelocity;

	public void Update() {
		transform.Rotate(RotationVelocity * Time.deltaTime);
	}
}
