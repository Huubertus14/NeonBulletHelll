using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyMovement : MonoBehaviour
{
    private Vector2 _goalPosition;
    private Vector2 _originPosition;

    private float _movementTime = 1.5f;
    private float _movement = 0;

    private float _yMovement = 1.5f;
    private float _xMovement = 0.5f;

	private void Awake()
	{
        _goalPosition = transform.position;
        _originPosition = transform.position;
        _movement = 1.1f;
	}

	private void Update()
    {
		if(GameManager.IsGamePlaying)
		{
            _movement += Time.deltaTime / _movementTime;
            if(_movement <= 1)
            {
                transform.position = Vector2.Lerp(_originPosition, _goalPosition, _movement);
            }
			else 
            {
                GetNewGoal();
			}

            CheckIfDead();
		}    
    }

    private void CheckIfDead()
	{
		if(transform.position.y < -5.5f)
		{
            Destroy(gameObject);
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var col = collision.gameObject.GetComponent<DefaultEnemyBehaviour>();
        if(col != null)
        {
            _goalPosition = transform.position;
            _originPosition = transform.position;

            GetNewGoal();
        }
    }

    private void GetNewGoal()
	{
        _movement = 0;
        _originPosition = transform.position;
        _goalPosition.y = transform.position.y - _yMovement;
        _goalPosition.x = Random.Range(_goalPosition.x - _xMovement, _goalPosition.x + _xMovement);
    }
}
