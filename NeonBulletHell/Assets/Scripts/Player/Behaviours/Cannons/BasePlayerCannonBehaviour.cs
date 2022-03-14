using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerCannonBehaviour<T> : MonoBehaviour where T : DefaultBullet
{
	[SerializeField] protected abstract GameObject BulletPrefab { get; }
	[SerializeField] private Transform _bulletPoint;

	private ObjectPool<T> _bulletPool;
	private float _timer;

	[SerializeField] protected abstract int BulletPoolSize { get; }
	[SerializeField] protected abstract float InitialFireInterval { get; }

	protected float FireInterval;

	protected virtual void Awake()
	{
		ResetCannon();
	}

	public void ResetCannon()
	{
		if(_bulletPool != null)
		{
			_bulletPool.Dispose();
		}
		_bulletPool = new ObjectPool<T>(BulletPrefab, BulletPoolSize, HideFlags.HideInHierarchy);
		_timer = 0;
		FireInterval = InitialFireInterval;
	}

	private void FixedUpdate()
	{
		TouchInput();
		MouseInput();
	}

	public abstract void UpdateFireInterval();

	private void TouchInput()
	{
		if(Input.touches.Length > 0)
		{
			_timer += Time.deltaTime;
			if(_timer >= FireInterval)
			{
				FireCannon();
			}
		}
	}

	private void MouseInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			FireCannon();
		}
		if(Input.GetMouseButton(0))
		{
			_timer += Time.deltaTime;
			if(_timer >= FireInterval)
			{
				FireCannon();
			}
		}
	}

	private void FireCannon()
	{
		T bullet = _bulletPool.GetPoolObject();
		if(bullet != null)
		{
			bullet.transform.position = _bulletPoint.position;
			bullet.FireBullet(new Vector2(0, 1), 300);
			_timer = 0;
		}
	}
}
