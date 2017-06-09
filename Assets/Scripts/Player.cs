using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float MoveSpeed = 10f;
	public Transform Body;
	
	private CharacterController _characterController;

	private void Awake() {
		_characterController = GetComponent<CharacterController>();
	}

	private void Update() {
		Vector3 moveAmt = GetMoveAmount() * MoveSpeed;

		if (moveAmt.magnitude > 0f)
		{
			_characterController.Move(moveAmt * Time.deltaTime);
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
		}

		Body.forward = GetAimDirection();
	}

	private Vector3 GetMoveAmount()
	{
		return new Vector3(
				Input.GetAxis("Horizontal"),
				0f,
				Input.GetAxis("Vertical")
			);
	}

	private Vector3 GetAimDirection()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1000f))
		{
			Vector3 dir = hit.point - transform.position;
			dir.y = 0f;
			return dir.normalized;
		}
		return Vector3.forward;
	}
}
