using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonSpeedPowerUp : MonoBehaviour, IPlayerPowerUp
{
	private BasePlayerCannonBehaviour<DefaultPlayerBullet> _defaultCannon;
	private BasePlayerCannonBehaviour<PiercingPlayerBullet> _piercingCannon;

	private void Awake()
	{
		_defaultCannon = GetComponent<BasePlayerCannonBehaviour<DefaultPlayerBullet>>();
		_piercingCannon= GetComponent<BasePlayerCannonBehaviour<PiercingPlayerBullet>>();
	}

	public void ApplyPowerUp()
	{
		_defaultCannon.UpdateFireInterval();
		_piercingCannon.UpdateFireInterval();
	}
}
