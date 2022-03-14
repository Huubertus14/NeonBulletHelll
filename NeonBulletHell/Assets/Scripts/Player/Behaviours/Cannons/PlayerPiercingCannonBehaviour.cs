using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiercingCannonBehaviour : BasePlayerCannonBehaviour<PiercingPlayerBullet>
{
	[SerializeField] private GameObject _bulletPrefab;

	protected override GameObject BulletPrefab => _bulletPrefab;
	protected override int BulletPoolSize => 35;
	protected override float InitialFireInterval => 1.5f;

	protected override void Awake()
	{
		base.Awake();
		enabled = false;
	}

	public override void UpdateFireInterval()
	{
		FireInterval *= 0.95f;
	}
}
