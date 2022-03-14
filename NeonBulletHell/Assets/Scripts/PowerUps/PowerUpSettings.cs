using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpSettings", menuName = "ScriptableObjects/PowerUpSettings", order = 1)]
public class PowerUpSettings : ScriptableObject
{
	public List<PowerUp> PowerUps;
}

[System.Serializable]
public class PowerUp
{
	public GameObject PowerUpPrefab;
	public int Weight = 1;
}
