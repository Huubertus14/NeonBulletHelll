using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPowerUpMovement : MonoBehaviour
{
	private float _timer;
	private float _jumpiness;
	private Vector2 _goalPosition;
	private Vector2 _originPosition;

	private void Awake()
	{
		_originPosition = transform.position;
		_goalPosition = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
		_jumpiness = Random.Range(0.4f, 2.8f);
		_timer = 0;
	}

	void Update()
	{
		if(GameManager.IsGamePlaying)
		{
			_timer += Time.deltaTime / _jumpiness;
			if(_timer > 1)
			{
				_goalPosition = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
				_originPosition = transform.position;
				_timer = 0;
			}
			else
			{
				transform.position = Vector2.Lerp(_originPosition, _goalPosition, _timer);
			}

			CheckIfInScreen();
		}
    }

    public void CheckIfInScreen()
	{
		if(transform.position.y < -5.5f || transform.position.y > 5.5f)
		{
			Destroy(gameObject);
		}

		if(transform.position.x < -3f|| transform.position.y > 3f)
		{
			Destroy(gameObject);
		}
	}
}
