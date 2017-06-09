using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour 
{

	public static Shaker Instance { get; private set; }

	[SerializeField]
	private float shakeSpeed = 10f;
	[SerializeField]
	private float shakeDecay = 1.5f;
	[SerializeField]
	private float shakeAttackTime = 0.1f;

	private float shakeAmt = 0f;
	private float lastShakeTime = 0;
	private Quaternion startingRotation;

	void Awake()
	{
		Instance = this;
		startingRotation = transform.rotation;
	}

	public void Shake(float amt)
	{
		shakeAmt = Mathf.Max(shakeAmt, amt);
		lastShakeTime = Time.time;
	}

	void Update()
	{
		if (shakeAmt > 0f)
		{
			shakeAmt = shakeAmt / shakeDecay;

			if (shakeAmt < 0.001f) { shakeAmt = 0f; }
		}

		transform.rotation = startingRotation * Quaternion.Euler(new Vector3(
					(Mathf.PerlinNoise(Time.time * shakeSpeed, 0.25f) - 0.5f) * shakeAmt,
					(Mathf.PerlinNoise(Time.time * shakeSpeed, 0.75f) - 0.5f) * shakeAmt,
					0f) * Mathf.Clamp01((Time.time - lastShakeTime) / shakeAttackTime));
	}

}
