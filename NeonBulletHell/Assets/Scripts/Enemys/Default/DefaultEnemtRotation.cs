using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemtRotation : MonoBehaviour
{
	private Vector3 _rotation;

	private void Awake()
	{
		_rotation = new Vector3(0, 0, Random.Range(12f, 24f));
	}

	private void FixedUpdate()
	{
		transform.Rotate(_rotation* Time.deltaTime);
	}
}
