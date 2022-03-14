using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIHearthController : MonoBehaviour
{
    [SerializeField] private GameObject _heartObject;
	private List<GameObject> _hearts = new List<GameObject>();

	private void OnEnable()
	{
		_heartObject.SetActive(false);
		PlayerHitBehaviour.OnLivesUpdated += UpdateLives;
	}

	private void UpdateLives(int lives)
	{
		foreach(GameObject heart in _hearts)
		{
			heart.SetActive(false);
		}

		if(lives >= _hearts.Count)
		{
			//Find diference
			int toCreate = lives - _hearts.Count;
			for(int i = 0; i < toCreate; i++)
			{
				GameObject g = Instantiate(_heartObject, transform);
				_hearts.Add(g);
			}
		}

		for(int i = 0; i < lives; i++)
		{
			_hearts[i].SetActive(true);
		}
	}

	private void OnDisable()
	{
		PlayerHitBehaviour.OnLivesUpdated -= UpdateLives;
	}
}
