using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
	public UnityEvent TriggerEntered;

	public void OnTriggerEnter(Collider collider) {
		TriggerEntered.Invoke();
	}
}
