using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyMovementBehaviour : MonoBehaviour
{
   private readonly Vector2 _movementBox = new Vector2(2.8f,5);

	private Vector2 _goalPosition;
	private Vector2 _originPosition;

	private float _movementTime;
	private float _timer;

	private void Awake()
	{
		_originPosition = transform.position;
		_goalPosition = new Vector2(_originPosition.x, Random.Range(1.5f, 4.8f));
		_timer = 0;
		_movementTime = Random.Range(1.8f, 3.5f);
	}

	private void FixedUpdate()
	{
		if(GameManager.IsGamePlaying)
		{
			_timer += Time.deltaTime;
			if(_timer > 1 + _movementTime)
			{
				_timer = 0;
				_originPosition = transform.position;
				_goalPosition = new Vector2(Random.Range(-_movementBox.x, _movementBox.x), Random.Range(1.5f, 4.8f));
				_movementTime = Random.Range(1.8f, 3.5f);
			}
			else
			{
				transform.position = Vector2.Lerp(_originPosition, _goalPosition, _timer);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var col = collision.gameObject.GetComponent<DefaultEnemyBehaviour>();
		if(col != null)
		{
			_goalPosition = transform.position;
			_originPosition = transform.position;
		}
	}
}
