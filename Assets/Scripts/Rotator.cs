using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
	public float speed = 2.0f;

	private Vector3 _angle;

	void Start()
	{
		_angle = GetRandomVector();
	}

	void Update ()
	{
		transform.Rotate(_angle * Time.deltaTime * speed);
	}

	Vector3 GetRandomVector()
	{
		return new Vector3(Random.Range(-10, 15), Random.Range(-30, 30), Random.Range(-45, 45));
	}
}