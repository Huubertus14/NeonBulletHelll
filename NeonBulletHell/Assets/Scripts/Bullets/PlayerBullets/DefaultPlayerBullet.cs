using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlayerBullet : DefaultBullet
{
	private int _damage =1;

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		var colide = collision.gameObject.GetComponent<DefaultEnemyBehaviour>();
		if(colide != null)
		{
			colide.Hit(_damage);
			gameObject.SetActive(false);
		}
	}
}
