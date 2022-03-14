using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScaleAnimation : MonoBehaviour
{
    [SerializeField] private float _duration=1;
    [SerializeField] private float _multiplier=1;
    [SerializeField] private AnimationCurve _animation;


    private float _timer;

    private Vector3 _originScale;
    private Transform _myTransform;
    private float _tweenValue;

    private void Start()
    {
        _timer = 0;
        _myTransform = transform;
        _originScale = _myTransform.localScale;
    }

   private void FixedUpdate()
    {
        _timer += Time.deltaTime / _duration;
		if(_timer <= 1)
		{
			_tweenValue = _animation.Evaluate(_timer);
            _myTransform.localScale = _originScale * _tweenValue * _multiplier;
		}
		else
		{
            _timer = 0;
		}
    }
}
