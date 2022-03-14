using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyBulletBehaviour : DefaultBullet
{
	private int _damage = 1;

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		var colidePlayer = collision.gameObject.GetComponent<PlayerHitBehaviour>();
		if(colidePlayer != null)
		{
			colidePlayer.Hit(_damage);
			gameObject.SetActive(false);
		}

		var colideEnemy = collision.gameObject.GetComponent<DefaultEnemyBehaviour>();
		if(colideEnemy != null)
		{
			colideEnemy.Hit(_damage);
			gameObject.SetActive(false);
		}
	}
}
