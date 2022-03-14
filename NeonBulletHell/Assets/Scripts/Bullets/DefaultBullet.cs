using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefaultBullet : MonoBehaviour
{
	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	public void FireBullet(Vector2 movement, float force)
	{
		_rigidbody.AddForce(movement * force);
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		
	}
}
