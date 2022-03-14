using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static bool IsGamePlaying => _instance._isPlaying;

	private static GameManager _instance;
	private bool _isPlaying;

	private void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
		}
		else
		{
			Debug.LogError("Multiple GameManagers detected, Destroyed this one");
			Destroy(this);
		}

		SceneManager.sceneLoaded += OnSceneLoaded;
		_instance._isPlaying = false;
	}

	public static void StartGame()
	{
		_instance._isPlaying = true;
	}

	public static void StopGame()
	{
		_instance._isPlaying = false;
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		if(arg0.name.Equals("GameScene"))
		{
			StartGame();
		}
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}
