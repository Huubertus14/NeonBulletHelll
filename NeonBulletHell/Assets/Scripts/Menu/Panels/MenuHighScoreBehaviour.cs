using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MenuHighScoreBehaviour : MonoBehaviour
{
	private TextMeshProUGUI _text;
	private PlayerScoreModel _scoreModel;

	private void Awake()
	{
		string path = Path.Combine(Application.persistentDataPath, "HighScoreSettings.json");
		_text = GetComponent<TextMeshProUGUI>();
		_scoreModel =PlayerScoreModel.FromJson(path);
		SetText();
	}

	private void SetText()
	{
		_text.text = $"HighScore:\n{_scoreModel.HighScore}";
	}
}
