using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;

	[SerializeField]private Transform _playerTransform;

	private void Awake()
	{
		if(_instance== null)
		{
			_instance = this;
		}
		else
		{
			Destroy(_instance);
		}
	}

	public static Transform GetPlayer
	{
		get { return _instance._playerTransform; }
	}
}
