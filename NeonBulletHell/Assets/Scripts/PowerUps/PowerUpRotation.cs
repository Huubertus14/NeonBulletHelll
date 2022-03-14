using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{
	[SerializeField] private Vector3 _rotation;
	private Transform _myTransform;

	private void Awake()
	{
		_myTransform = transform;
	}

	private void FixedUpdate()
	{
		_myTransform.Rotate(_rotation);
	}
}
