using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class StartGameButton : MonoBehaviour
{
	private Button _startButton;

	private void Awake()
	{
		_startButton = GetComponent<Button>();
		_startButton.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		SceneManager.LoadScene(2, LoadSceneMode.Single);
	}

	private void OnDestroy()
	{
		_startButton.onClick.RemoveListener(OnClick);
	}
}
