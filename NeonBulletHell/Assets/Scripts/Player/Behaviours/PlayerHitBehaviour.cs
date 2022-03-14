using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBehaviour : MonoBehaviour, IHitable
{
	public delegate void LivesUpdated(int lives);
	public static event LivesUpdated OnLivesUpdated;

	private int _lives = 3;

	private void Start()
	{
		OnLivesUpdated?.Invoke(_lives);
	}

	public void Hit(int damage)
	{
		_lives -= damage;
		OnLivesUpdated?.Invoke(_lives);
		if(_lives < 0)
		{
			PlayerDied();
		}
	}

	public void AddLive(int amount)
	{
		_lives += amount;
		OnLivesUpdated?.Invoke(_lives);
	}

	private void PlayerDied()
	{
		PlayerScoreController.SaveScore();
		GameManager.StopGame();
	}
}
