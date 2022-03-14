using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObjects/SpawnData", order = 1)]
public class SpawnData : ScriptableObject
{
	[SerializeField] public List<Spawn> EnemyData;
	
	[System.Serializable]
	public class Spawn
	{
		public EnemyTypes EnemyType;
		public GameObject Prefab;
		public int Quantity = 1;
	}
}

