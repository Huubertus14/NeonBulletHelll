using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraLivePowerUp : MonoBehaviour, IPlayerPowerUp
{
	private PlayerHitBehaviour _playerHit;

	private void Awake()
	{
		_playerHit = GetComponent<PlayerHitBehaviour>();
	}

	public void ApplyPowerUp()
	{
		_playerHit.AddLive(1);
	}
}
