using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionGenerator : MonoBehaviour
{
	private Collider2D _boxCollider;

	private void Awake()
	{
		_boxCollider = GetComponent<Collider2D>();
	}

	public Vector2 GetSpawnPosition()
	{
		return new Vector2(Random.Range(_boxCollider.bounds.min.x, _boxCollider.bounds.max.x), Random.Range(_boxCollider.bounds.min.y, _boxCollider.bounds.max.y));
	}
}
