using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform Target;
	public float SmoothDamp = 1f;
	public bool Enabled;
	
	private Vector3 startingOffset;
	private Vector3 cameraOffset;
	private Vector3 velocity;

	private void Start() {
		startingOffset = transform.position - Target.position;
	}

	void Update()
	{
        cameraOffset = startingOffset;

        if (Target != null)
		{
			float smoothDamp = Enabled ? SmoothDamp : 0;
			Vector3 targetPos = Vector3.SmoothDamp(
				transform.position,
				Target.transform.position + cameraOffset,
				ref velocity,
				smoothDamp
			);
			
			transform.position = targetPos;
        }
    }

	public void EnableSmoothDamp() {
		Enabled = true;
	}
}
