using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyFireScript : MonoBehaviour
{
	[SerializeField]private GameObject _bulletPrefab;
	[SerializeField] private Transform _bulletPoint;

    private float _timer;
    private float _shootInterval = 1.5f;

	private ObjectPool<DefaultEnemyBulletBehaviour> _bulletPool;

	private void Awake()
	{
		_bulletPool = new ObjectPool<DefaultEnemyBulletBehaviour>(_bulletPrefab, 15, HideFlags.HideInHierarchy);
		_timer = 0;
	}

	private void Update()
	{
		if(GameManager.IsGamePlaying)
		{
			_timer += Time.deltaTime;
			if(_timer > _shootInterval)
			{
				_timer = 0;
				Fire();
			}
		}
	}

	private void Fire()
	{
		DefaultEnemyBulletBehaviour bullet = _bulletPool.GetPoolObject();
		bullet.transform.position = _bulletPoint.position;
		bullet.FireBullet(new Vector2(0,-1), 250);
	}
}
