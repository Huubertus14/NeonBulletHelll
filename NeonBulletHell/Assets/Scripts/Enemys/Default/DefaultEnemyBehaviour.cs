using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyBehaviour : MonoBehaviour, IHitable
{
	[SerializeField]private int _lives = 2;
	[SerializeField] private int _score = 150;

	public void Hit(int damage)
	{
		_lives-= damage;
		if(_lives<=0)
		{
			PlayerScoreController.AddScore(_score);
			PowerUpController.Instance.EnemyDiedPowerUpSpawn(transform.position);
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerHitBehaviour player = collision.gameObject.GetComponent<PlayerHitBehaviour>();
		if(player!=null)
		{
			player.Hit(1);
			Destroy(gameObject);
		}
	}

}
