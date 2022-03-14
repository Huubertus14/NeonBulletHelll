using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Linq.Expressions;

public class EnemySpawnController : MonoBehaviour
{
	public float SpawnInterval{ get; set; }

    private float _spawnTimer;
	private SpawnPositionGenerator _spawnPositionGenerator;
	private SpawnData _settings;

	private void Awake()
	{
		_spawnPositionGenerator = GetComponentInChildren<SpawnPositionGenerator>();
		_spawnTimer = 0;
		SpawnInterval = 2.5f;
		_settings = Resources.Load<SpawnData>("SpawnData");
	}

	private void Update()
	{
		if(GameManager.IsGamePlaying)
		{
			if(SpawnInterval >=0.3f)
			{
				SpawnInterval -= Time.deltaTime / 800f;
			}
			
			_spawnTimer += Time.deltaTime;

			if(_spawnTimer >= SpawnInterval)
			{
				SpawnEnemys();
				_spawnTimer = 0;
			}
		}
	}

	private void SpawnEnemys()
	{
		var EnemyType = GetRandomEnemyType();
		SpawnData.Spawn e = _settings.EnemyData.FirstOrDefault(q=>q.EnemyType.Equals(EnemyType));

		if(e != null)
		{
			for(int i = 0; i < e.Quantity; i++)
			{
				GameObject enemy = Instantiate(e.Prefab, _spawnPositionGenerator.GetSpawnPosition(), Quaternion.Euler(0, 0, 180));
			}
		}
	}

	private EnemyTypes GetRandomEnemyType()
	{
		int index = UnityEngine.Random.Range(0, Enum.GetNames(typeof(EnemyTypes)).Length);
		return (EnemyTypes)index;
	}
}
