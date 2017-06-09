using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour 
{

	[SerializeField]
	private float lifetime = 3f;

	private float awakeTime;

	void Awake()
	{
		awakeTime = Time.time;
	}

	void Update()
	{
		if (Time.time - awakeTime >= lifetime)
		{
			Destroy(gameObject);
		}
	}

}
