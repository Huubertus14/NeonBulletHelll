using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpBehaviour : MonoBehaviour
{
	Dictionary<PowerUpType, IPlayerPowerUp> _powerUps;

	private void Awake()
	{
		_powerUps = new Dictionary<PowerUpType, IPlayerPowerUp>
		{
			{ PowerUpType.CannonSpeed, gameObject.AddComponent<PlayerCannonSpeedPowerUp>() },
			{ PowerUpType.ExtraLive, gameObject.AddComponent<PlayerExtraLivePowerUp>() },
			{ PowerUpType.DefaultCannon, gameObject.AddComponent<PlayerDefaultCannonPowerUp>() },
			{ PowerUpType.PiercingCannon, gameObject.AddComponent<PlayerPiercingCannonPowerUp>() }
		};
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DefaultPowerUpBehaviour powerUp = collision.gameObject.GetComponent<DefaultPowerUpBehaviour>();
		if(powerUp != null)
		{
			Destroy(powerUp.gameObject);
			_powerUps[powerUp.GetPowerUp].ApplyPowerUp();
		}
	}
}
