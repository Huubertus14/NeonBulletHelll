using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
	private Vector2 _goalPosition;
	private Transform _myTransform;
	private Camera _mainCamera;

	[SerializeField]private float _movementSpeed = 6f;

	private void Awake()
	{
		_mainCamera = Camera.main;
		_myTransform = transform;
		_goalPosition = _myTransform.position;
	}

	private void FixedUpdate()
	{
		if(HasInput())
		{
			UpdatePosition();
		}
	}

	private bool HasInput()
	{
		if(Input.touches.Length > 0)
		{
			_goalPosition = _mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
			return true;
		}

		if(Input.GetMouseButton(0))
		{
			_goalPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
			return true;
		}

		return false;
	}

	private void UpdatePosition()
	{
		_myTransform.position = Vector2.MoveTowards(_myTransform.position, _goalPosition, Time.deltaTime * _movementSpeed);
	}
}
