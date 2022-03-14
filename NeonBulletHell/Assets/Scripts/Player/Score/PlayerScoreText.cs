using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;

public class PlayerScoreText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
		PlayerScoreController.OnScoreUpdate += ScoreChanged;
    }

	private void ScoreChanged(int score)
	{
		_text.text = $"{score}";
	}
}
