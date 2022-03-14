using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerScoreController : MonoBehaviour
{
	public delegate void ScoreUpdated(int score);
	public static event ScoreUpdated OnScoreUpdate;

	private int _score;
	private static PlayerScoreController _instance;
	private float _timer;
	private float _scoreTime;
	private PlayerScoreModel _scoreSettings;

	private static string _path; 

	private void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
		}
		else
		{
			Destroy(_instance);
		}

		_path = Path.Combine(Application.persistentDataPath, "HighScoreSettings.json");
		_instance._scoreTime = 0.05f;
		_instance._score = 0;
		_instance._scoreSettings = PlayerScoreModel.FromJson(_path);
	}

	private void Update()
	{
		if(GameManager.IsGamePlaying)
		{
			_instance._timer += Time.deltaTime;

			if(_instance._timer > _instance._scoreTime)
			{
				_instance._timer = 0;
				AddScore(4);
			}
		}
	}

	public static void AddScore(int scoreToAdd)
	{
		_instance._score += scoreToAdd;
		OnScoreUpdate?.Invoke(_instance._score);
	}

	public static void SaveScore()
	{
		if(_instance._score > _instance._scoreSettings.HighScore)
		{
			_instance._scoreSettings.HighScore = _instance._score; 
			_instance._scoreSettings.SaveToJson(_path);
		}
	}
}
