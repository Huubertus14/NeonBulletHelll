using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public static PowerUpController Instance;
	
	private PowerUpSettings _settings;
	[SerializeField]private List<GameObject> _powerUps = new List<GameObject>();

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}

		_settings = Resources.Load<PowerUpSettings>("PowerUpSettings");
		for(int i = 0; i < _settings.PowerUps.Count; i++)
		{
			for(int j = 0; j < _settings.PowerUps[i].Weight; j++)
			{
				_powerUps.Add(_settings.PowerUps[i].PowerUpPrefab);
			}
		}
	}

	public void EnemyDiedPowerUpSpawn(Vector2 position)
	{
		int ran = Random.Range(1,10);
		if(ran == 1)
		{
			SpawnRandomPowerUp(position);
		}
	}

	private void SpawnRandomPowerUp(Vector2 position)
	{
		GameObject powerUp = Instantiate(_powerUps[Random.Range(0, _powerUps.Count)], position, Quaternion.identity);
	}
}
