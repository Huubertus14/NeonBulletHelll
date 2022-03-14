using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultCannonBehaviour : BasePlayerCannonBehaviour<DefaultPlayerBullet>
{
	[SerializeField] private GameObject _bulletPrefab;

	protected override GameObject BulletPrefab=> _bulletPrefab;
	protected override int BulletPoolSize => 35;
	protected override float InitialFireInterval => 1.2f;

	public override void UpdateFireInterval()
	{
		FireInterval *= 0.9f;
	}
}
