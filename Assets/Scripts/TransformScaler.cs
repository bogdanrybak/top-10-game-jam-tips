using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ScalerData
{
	public Vector3 From;
	public Vector3 To;
	public EaseType EaseType;
	public float Duration;
}

public class TransformScaler : MonoBehaviour
{
	public ScalerData[] ScaleNodes;
	public bool ScaleOnAwake;
	public bool UseUnscaledTime;

	void OnEnable()
	{
		if (ScaleOnAwake)
			Scale();
	}

	IEnumerator ExecuteScaleRoutine(int start, int end)
	{
		for (int i = start; i < end + 1; i++)
		{
			var node = ScaleNodes[i];
			transform.localScale = node.From;
			yield return StartCoroutine(transform.ScaleTo(node.To, node.Duration, Ease.FromType(node.EaseType)));
		}
	}

	public void Scale()
	{
		if (gameObject.activeInHierarchy)
		{
			StopAllCoroutines();
			StartCoroutine(ExecuteScaleRoutine(0, ScaleNodes.Length -1));
		}
	}
	
	public void PlayRange(int start, int end)
	{
		if (gameObject.activeInHierarchy)
		{
			StopAllCoroutines();
			StartCoroutine(ExecuteScaleRoutine(start, end));
		}
	}
	
	public void PlayNode(int index)
	{
		if (gameObject.activeInHierarchy)
		{
			StopAllCoroutines();
			StartCoroutine(PlayNodeAsync(index));
		}
	}
	
	IEnumerator PlayNodeAsync(int index)
	{
		yield return StartCoroutine(transform.ScaleTo(ScaleNodes[index].To, ScaleNodes[index].Duration, Ease.FromType(ScaleNodes[index].EaseType)));
	}
	
	public void Reset()
	{
		transform.localScale = Vector3.one;
	}
}