using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class KamikazeEnemyMovementBehaviour : MonoBehaviour
{
	private Vector2 _originPosition;
	private Vector3 _goalPosition;

	private SpriteRenderer _spr;

	[SerializeField]private Color _beginColor;
	[SerializeField]private Color _attackColor;

	private Transform _playerTransform;
	private float _spawnTimer;
	private float _spawnMovementTime = 2.4f;
	private float _lockOnTime = 1.5f;
	private float _lockOnTimer;

	private float _kamikazeSpeed = 1.5f;
	private float _angle = 0;

	private void Awake()
	{
		_playerTransform = PlayerController.GetPlayer;
		_originPosition = transform.position; 
		_goalPosition = new Vector2(_originPosition.x, Random.Range(1.5f, 4.8f));
		_spr = GetComponent<SpriteRenderer>();
		_spr.color = _beginColor;
		transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
	}

	private void FixedUpdate()
	{
		if(GameManager.IsGamePlaying)
		{
			_spawnTimer += Time.deltaTime / _spawnMovementTime;
			if(_spawnTimer <=1)
			{
				transform.position = Vector2.Lerp(_originPosition, _goalPosition, _spawnTimer);
			}
			else // Inkamikaze stage
			{
				//Count other Timer
				if(_lockOnTimer > 1)
				{
					//Move forward
					transform.position += (transform.up*-1) * _kamikazeSpeed * Time.deltaTime;
					_kamikazeSpeed *= 1.05f;
				}
				else
				{
					_lockOnTimer += Time.deltaTime / _lockOnTime;
					//Look at playe
					_spr.color = Color.Lerp(_beginColor, _attackColor, _lockOnTimer);
					Vector3 dir = _playerTransform.position - transform.position;
					_angle =Mathf.MoveTowards( _angle,Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90,10f);
					transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
				}
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
}
