using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultCannonPowerUp : MonoBehaviour, IPlayerPowerUp
{
	private PlayerDefaultCannonBehaviour _playerCannon;
	private PlayerPiercingCannonBehaviour _playerPiercingCannon;

	private void Awake()
	{
		_playerCannon = GetComponent<PlayerDefaultCannonBehaviour>();
		_playerPiercingCannon = GetComponent<PlayerPiercingCannonBehaviour>();
	}

	public void ApplyPowerUp()
	{
		_playerCannon.enabled = true;
		_playerPiercingCannon.enabled = false;
		_playerCannon.ResetCannon();
	}
}
